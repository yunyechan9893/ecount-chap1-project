using CommandThird._01_Command;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace CommandThird._03_PipeLine
{
    public class PipeLine : ICommand
    {
        private Queue<object> _items = new Queue<object>();

        public PipeLineItem<TInput, TOutput> Register<TInput, TOutput>(TInput input)
            where TInput : BaseCommand<TOutput>
        {
            var item = new PipeLineItem<TInput, TOutput>();
            item.Command = input;
            _items.Enqueue(item);
            return item;
        }

        public void Execute()
        {
            while (_items.Count > 0)
            {
                    var item = _items.Dequeue() as dynamic;
                    item.Execute(); // 각 PipeLineItem을 실행합니다.
            }
        }
    }

    public class PipeLineItem<TInput, TOutput> : ICommand
        where TInput : BaseCommand<TOutput>
    {
        public TInput Command { get; set; }

        private Predicate<BaseCommand<TOutput>> _filter { get; set; }
        private Action<TInput> _mapping { get; set; }
        private Action<TOutput> _action { get; set; }

        public PipeLineItem<TInput, TOutput> AddFilter(Predicate<BaseCommand<TOutput>> filter)
        {
            _filter = filter;

            return this;
        }

        // 매핑 메서드
        public PipeLineItem<TInput, TOutput> Mapping(Action<TInput> mapping)
        {
            _mapping = mapping;

            return this;
        }

        // 명령 실행 후 추가 작업 메서드
        public void Executed(Action<TOutput> action)
        {
            _action = action;
        }

        // 명령 실행 로직 메서드
        private void OnExecute()
        {
            if (Command != null)
            {
                if (!_filter(Command)) // 필터 적용
                {
                    throw new Exception("잘못된 명령입니다.");
                }

                _mapping(Command);

                Command.Execute();

                _action(Command.Output);
            }
            else
            {
                throw new InvalidOperationException("명령 기반이 설정되지 않았습니다.");
            }
        }

        // 외부에서 호출할 수 있는 실행 메서드
        public void Execute()
        {
            OnExecute();
        }
    }
}
