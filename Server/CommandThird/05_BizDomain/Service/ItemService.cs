using CommandThird._03_PipeLine;
using Data.Dac;
using Data.Entity;
using System.Collections.Generic;

namespace CommandThird._05_BizDomain
{
    public class ItemService
    {
        public static PipeLine PipeLine = new PipeLine();
        public List<ItemYyc> Select(long id)
        {
            List<ItemYyc> result = new List<ItemYyc>();
            PipeLine.Register<SelectItemDac, List<ItemYyc>>(new SelectItemDac())
                .AddFilter((cmd) => true)
                .Mapping((cmd) => cmd.Request = new SelectItemDacRequestDto()
                {
                    Id = id,
                })
                .Executed((res) => result = res);

            PipeLine.Execute();

            return result;
        }

        public int CREATE(string code, string name)
        {
            int result = 0;
            PipeLine.Register<InserItemDac, int>(new InserItemDac())
                .AddFilter((cmd) => true)
                .Mapping((cmd) => cmd.Request = new ItemYyc()
                {
                    CODE = code,
                    NAME = name
                })
                .Executed((res) => result = res);

            PipeLine.Execute();

            return result;
        }

        public int UPDATE(string code, string name)
        {
            int result = 0;
            PipeLine.Register<UpdateItemDac, int>(new UpdateItemDac())
                .AddFilter((cmd) => true)
                .Mapping((cmd) => cmd.Request = new ItemYyc()
                {
                    CODE = code,
                    NAME = name
                })
                .Executed((res) => result = res);

            PipeLine.Execute();

            return result;
        }

        public int DELETE(string code)
        {
            int result = 0;
            PipeLine.Register<DeleteItemDac, int>(new DeleteItemDac())
                .AddFilter((cmd) => true)
                .Mapping((cmd) => cmd.Request = new ItemYyc()
                {
                    CODE = code
                })
                .Executed((res) => result = res);

            PipeLine.Execute();

            return result;
        }
    }
}
