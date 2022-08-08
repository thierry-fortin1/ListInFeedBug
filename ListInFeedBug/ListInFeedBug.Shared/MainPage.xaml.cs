using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Uno.Extensions.Reactive;
using Windows.Foundation;
using Windows.Foundation.Collections;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ListInFeedBug
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            DataContext = this;
        }

        public IState<string> Title => State<string>.Value(this, () => "This is a title.");

        private IListState<string> _stateMessages => ListState<string>.Async(this, async ct => await GetStrings());

        public IListFeed<string> Messages => _stateMessages;

        private async ValueTask<IImmutableList<string>> GetStrings()
        {
            await Task.Delay(10);
            var list = new List<string> { "msg1", "msg2", "msg3", "msg4", "msg11", "msg2", "msg3", "msg4", "msg111", "msg2", "msg3", "msg4", "msg1111", "msg2", "msg3", "msg4", "msg11111", "msg2", "msg3", "msg4", "msg111111", "msg2", "msg3", "msg4" };
            return list.ToImmutableList();
        }



        public IFeed<Item[]> Items => Feed.Async(async ct => await GetItems());

        private static async ValueTask<Item[]> GetItems()
        {
            await Task.Delay(10);
            return new Item[]
            {
            new Item("msg1"),
            new Item("msg2"),
            new Item("msg3"),
            new Item("msg4"),
            new Item("msg5"),
            new Item("msg10"),
            new Item("msg2"),
            new Item("msg3"),
            new Item("msg4"),
            new Item("msg5"),
            new Item("msg100"),
            new Item("msg2"),
            new Item("msg3"),
            new Item("msg4"),
            new Item("msg5"),
            new Item("msg1000"),
            new Item("msg2"),
            new Item("msg3"),
            new Item("msg4"),
            new Item("msg5"),
            new Item("msg10000"),
            new Item("msg2"),
            new Item("msg3"),
            new Item("msg4"),
            new Item("msg5"),
            };
        }
    }
}
