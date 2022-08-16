using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using System.Threading.Tasks;
using Uno.Extensions.Reactive;

namespace ListInFeedBug
{
    [ReactiveBindable]
    public partial class ViewModel
    {
        public IState<string> Title => State<string>.Value(this, () => "This is a title.");


        public IListState<string> _stateMessages => ListState<string>.Async(this, async ct => await GetStrings());

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
