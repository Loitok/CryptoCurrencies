using CryptoCurrencies.Api.Clients.Implementations;
using CryptoCurrencies.Extensions;
using CryptoCurrencies.Helpers;
using CryptoCurrencies.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace CryptoCurrencies.Views.Windows
{
    public partial class MainWindow : Window
    {
        public RelayCommand<string> Sort { get; set; }
        private CoinGeckoClient Api { get; } = new CoinGeckoClient();
        public ObservableCollection<CoinMarketsViewModel> Coins { get; set; } = new ObservableCollection<CoinMarketsViewModel>();
        public ListSortDirection SortDirection { get; set; } = ListSortDirection.Ascending;
        public string SortedBy { get; set; } = "#";

        private void SortObservableCollection(string property)
        {
            var keyExtractor = UpdateSortParams(property, reverse: true);
            Coins.Sort(keyExtractor, SortDirection);
        }

        private Task<List<CoinMarketsViewModel>> GetCoins(int size, int page)
        {
            return Api.CoinsClient.GetCoinMarkets(
                vsCurrency: /*SelectedCurrency.Id*/ "usd",
                ids: Array.Empty<string>(),
                order: "market_cap_desc",
                perPage: size,
                page: page,
                sparkline: true,
                priceChangePercentage: "24h,7d",
                category: ""
            );
        }

        private static Func<CoinMarketsViewModel, object> KeyExtractor(string property) => property switch
        {
            "#" => c => c.MarketCapRank,
            "Name" => c => c.Name,
            "Price" => c => c.CurrentPrice,
            "24h %" => c => c.PriceChangePercentage24HInCurrency,
            "7d %" => c => c.PriceChangePercentage7DInCurrency,
            "Market Cap" => c => c.MarketCap,
            "Volume(24h)" => c => c.TotalVolume,
            "Circulating Supply" => c => c.CirculatingSupply,
            "Total Supply" => c => c.TotalSupply,
            _ => throw new NotImplementedException()
        };

        private Func<CoinMarketsViewModel, object> UpdateSortParams(string property, bool reverse)
        {
            var lambda = KeyExtractor(property);

            if (SortedBy == property && reverse)
            {
                SortDirection = SortDirection == ListSortDirection.Ascending ?
                    ListSortDirection.Descending :
                    ListSortDirection.Ascending;
            }
            else if (reverse)
            {
                SortDirection = ListSortDirection.Descending;
            }
            SortedBy = property;

            return lambda;
        }

        private void SelectCoin(object sender, MouseButtonEventArgs e)
        {
            //LoadingVisibility = Visibility.Visible;
            var selectedCoinId = (string)((Panel)sender).Tag;

            var w = new CoinView(selectedCoinId, "usd"/*(SelectedCurrency.Id*/)
            {
                WindowState = WindowState.Minimized,
                Width = ActualWidth,
                Height = ActualHeight
            };
            w.Show();
            w.Top += 25;
            w.Left += 25;
            w.FullyRendered += (_, _) =>
            {
                w.Show();

                w.CenterWindowOnScreen();
                w.WindowState = WindowState.Normal;
                //LoadingVisibility = Visibility.Collapsed;
            };
        }

        private async Task FetchData(int page = 1)
        {
            try
            {
                var coins = await GetCoins(size: 10, page);
                var keyExtractor = UpdateSortParams(SortedBy, reverse: false);

                await Dispatcher.BeginInvoke((Action)(() =>
                {
                    Coins.Clear();
                    coins.Sort(keyExtractor, SortDirection).ForEach(c => Coins.Add(c));
                }));

            }
            catch (Exception e)
            {
                //Dispatcher.Invoke(() =>
                //{
                //    LoadingTitle.Text = "Too many requests";
                //    LoadingDescription.Text = "Please wait for the API to be available again";
                //});
            }
        }

        public MainWindow()
        {
            Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");

            InitializeComponent();

            Sort = new RelayCommand<string>(SortObservableCollection);

            Task.Run(async () =>
            {
                await FetchData();
            });
        }
    }
}
