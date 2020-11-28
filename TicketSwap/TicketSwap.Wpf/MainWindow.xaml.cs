using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TicketSwap.Shared;
using TicketSwap.Wpf.Services;

namespace TicketSwap.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string _token;
        RestService<Ticket, string> _restService;
        NotifyService _notifyService;
        public MainWindow(string token)
        {
            InitializeComponent();
            _token = token;
            _restService = new RestService<Ticket, string>("https://localhost:44398", "/api/ticket", _token);
            _notifyService = new NotifyService("https://localhost:44398/api/ticketHub");

            _notifyService.AddHandler("TicketUpdate", async () => await Sync());

            _notifyService.Init();

            Sync();
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            Ticket ticket = new Ticket();
            ticket.EventName = textBox_eventName.Text;
            ticket.EventDate = datePicker_eventDate.SelectedDate ?? DateTime.Now;
            ticket.EventPrice = int.Parse(textBox_eventPrice.Text);
            _restService.Post(ticket);
        }

        private async Task Sync()
        {
            listBox.Items.Clear();
            var tickets = await _restService.Get();
            foreach (var item in tickets)
            {
                listBox.Items.Add(item);
            }
        }

        private async void Sync_Click(object sender, RoutedEventArgs e)
        {
            await Sync();
        }
    }
}
