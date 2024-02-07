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

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        Button[] buttons;
        Random random = new Random();
        int i;
        string player;
        string bot;
        public MainWindow()
        {
            InitializeComponent();
            buttons = [_1, _2, _3, _4, _5, _6, _7, _8, _9];
            foreach (Button button in buttons)
            {
                button.IsEnabled = false;
            }
            player = "X";
            bot = "O";
            i = 0;
        }

        private void click(object sender, RoutedEventArgs e)
        {
            (sender as Button).Content = player;
            (sender as Button).IsEnabled = false;
            buttons = buttons.Where(i => i != (sender as Button)).ToArray();
            if (buttons.Length > 0)
            {
                int index = random.Next(buttons.Length);
                buttons[index].Content = bot;
                buttons[index].IsEnabled = false;
                buttons = buttons.Where(d => d != buttons[index]).ToArray();
            }
            if (CheckForWin(player))
            {
                Block.Text = "е ништяк победа игрока";
                play.IsEnabled = true;
                foreach (Button button in buttons)
                {
                    button.IsEnabled = false;
                }
            }
            else if (CheckForWin(bot))
            {
                Block.Text = "блин не ништяк победа рандома";
                play.IsEnabled = true;
                foreach (Button button in buttons)
                {
                    button.IsEnabled = false;
                }
            }
            if (buttons.Length == 0)
            {
                if (!CheckForWin(player) & !CheckForWin(bot))
                {
                    Block.Text = "ема ничья уважаемо";
                    play.IsEnabled = true;
                    foreach (Button button in buttons)
                    {
                        button.IsEnabled = false;
                    }
                }
            }
        }
        private bool CheckForWin(string kv)
        {
            if ((_1.Content == kv && _2.Content == kv && _3.Content == kv) || (_4.Content == kv && _5.Content == kv && _6.Content == kv) || (_7.Content == kv && _8.Content == kv && _9.Content == kv) || (_1.Content == kv && _4.Content == kv && _7.Content == kv) || (_2.Content == kv && _5.Content == kv && _8.Content == kv) || (_3.Content == kv && _6.Content == kv && _9.Content == kv) || (_1.Content == kv && _5.Content == kv && _9.Content == kv) || (_3.Content == kv && _5.Content == kv && _7.Content == kv))
            {
                return true;
            }
            return false;
        }

        private void play_Click(object sender, RoutedEventArgs e)
        {
            buttons = [_1, _2, _3, _4, _5, _6, _7, _8, _9];
            foreach (Button button in buttons)
            {
                button.IsEnabled = true;
                button.Content = "";
            }
            Block.Text = "";
            play.IsEnabled = false;
            i++;
            if (i % 2 == 0)
            {
                player = "O";
                bot = "X";
            }
            else
            {
                player = "X";
                bot = "O";
            }

        }
    }
}

