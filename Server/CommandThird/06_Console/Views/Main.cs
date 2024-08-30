using CommandThird._06_Console.Views;
using System;

namespace CommandThird
{
    
    public class MainView
    {
        public static bool isStarted = true;
        public void Main() { 
            while (isStarted)
            {
                var select = Print(Text.START_MENT);

                switch (select)
                {
                    case "1":
                        executeProduct();
                        break;
                    case "2":
                        executeSale();
                        break;
                    default:
                        Console.WriteLine(Text.END_MENT);
                        isStarted = false;
                        break;
                }
            }
        }

        private void executeProduct()
        {
            var select = Print(Text.EXECUTING_PRODUCT_MENT);

            switch (select)
            {
                case "1":
                    string comCode = Print(Text.COMCODE_PRODUCT);

                    Controller.SelectProduct(comCode);
                    break;
                case "5":
                    comCode = Print(Text.COMCODE_PRODUCT);
                    string prodCd = Print(Text.PROD_CD_PRODUCT);

                    Controller.FetchProduct(comCode, prodCd);
                    break;
                case "2":
                    comCode = Print(Text.COMCODE_PRODUCT);
                    prodCd = Print(Text.PROD_CD_PRODUCT);
                    int price = PrintInt(Text.PRICE_PRODUCT);
                    string prodNm = Print(Text.PROD_NM);

                    Controller.CreateProduct(comCode, prodCd, price, prodNm);
                    break;
                case "3":
                    comCode = Print(Text.COMCODE_PRODUCT);
                    prodCd = Print(Text.PROD_CD_PRODUCT);
                    price = UpdatePrintInt(Text.PRICE_PRODUCT);
                    prodNm = UpdatePrint(Text.PROD_NM);

                    Controller.UpdateProduct(comCode, prodCd, price, prodNm);
                    break;
                case "4":
                    comCode = Print(Text.COMCODE_PRODUCT);
                    prodCd = Print(Text.PROD_CD_PRODUCT);

                    Controller.DeleteProduct(comCode, prodCd);
                    break;
                default:
                    Console.WriteLine(Text.END_MENT);
                    isStarted = false;
                    break;
            }
        }

        private void executeSale()
        {
            var select = Print(Text.EXECUTING_SALE_MENT);

            switch (select)
            {
                case "1":
                    string comCode = Print(Text.COMCODE_SALE);

                    Controller.SelectSale(comCode);
                    break;
                case "2":
                    comCode = Print(Text.COMCODE_SALE);
                    var ioDate = Print(Text.IO_DATE_SALE);
                    var ioNo = PrintInt(Text.IO_NO_SALE);
                    var prodCd = Print(Text.PROD_CD_SALE);
                    var qty = PrintInt(Text.QUANTITY_SALE);
                    var remarks = Print(Text.REMARKS_SALE);

                    Controller.CreateSale(comCode, ioDate, ioNo, prodCd, qty, remarks);
                    break;
                case "3":
                    comCode = Print(Text.COMCODE_SALE);
                    ioDate = Print(Text.IO_DATE_SALE);
                    ioNo = PrintInt(Text.IO_NO_SALE);
                    prodCd = UpdatePrint(Text.PROD_CD_SALE);
                    qty = PrintInt(Text.QUANTITY_SALE);
                    remarks = UpdatePrint(Text.REMARKS_SALE);

                    Controller.UpdateSale(comCode, ioDate, ioNo, prodCd, qty, remarks);
                    break;
                case "4":
                    comCode = Print(Text.COMCODE_SALE);
                    ioDate = Print(Text.IO_DATE_SALE);
                    ioNo = PrintInt(Text.IO_NO_SALE);

                    Controller.DeleteSale(comCode, ioDate, ioNo);
                    break;

                case "5":
                    comCode = Print(Text.COMCODE_SALE);
                    ioDate = Print(Text.IO_DATE_SALE);
                    ioNo = PrintInt(Text.IO_NO_SALE);
                    // order
                    var orderBySaleCode = Print(Text.ORDER_BY_SALE_CODE);
                    var orderByQuantity = Print(Text.ORDER_BY_QUANTITY);

                    Controller.FetchSale(comCode, ioDate, ioNo, orderBySaleCode, orderByQuantity);
                    break;
                default:
                    Console.WriteLine(Text.END_MENT);
                    isStarted = false;
                    break;
            }
        }

        private string Print(string text)
        {
            Console.WriteLine(text);
            var input = Console.ReadLine();

            Console.Clear();
            return input;
        }

        private int PrintInt(string text)
        {
            return int.Parse(Print($"{text}{Text.NUMBER_CASE}"));
        }

        private string UpdatePrint(string text)
        {
            return Print($"{text}{Text.UPDATE_CASE}");
        }

        private int UpdatePrintInt(string text)
        {
            return int.Parse(Print($"{text}{Text.UPDATE_CASE}{Text.NUMBER_CASE}"));
        }
    }
}
