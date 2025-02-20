namespace MAUI_Projects
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnGenerateLuckyNumbers(object sender, EventArgs e)
        {
            NameApp.IsVisible = false;
            ContainerLuckyNumbers.IsVisible = true;
            var listNumbers = GenerateLuckyNumbers();
            LuckyNumber01.Text = listNumbers.ElementAt(0).ToString("D2");
            LuckyNumber02.Text = listNumbers.ElementAt(1).ToString("D2");
            LuckyNumber03.Text = listNumbers.ElementAt(2).ToString("D2");
            LuckyNumber04.Text = listNumbers.ElementAt(3).ToString("D2");
            LuckyNumber05.Text = listNumbers.ElementAt(4).ToString("D2");
            LuckyNumber06.Text = listNumbers.ElementAt(5).ToString("D2");
        }

        private SortedSet<int> GenerateLuckyNumbers()
        {
            var listNumbers = new SortedSet<int>();
            while (listNumbers.Count < 6)
            {
                var random = new Random();
                var luckyNumber = random.Next(1, 60);
                listNumbers.Add(luckyNumber);
            }
            return listNumbers;
        }
    }
}
