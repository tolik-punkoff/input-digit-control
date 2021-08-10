using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Globalization;

namespace InputDigit2
{
    public class InputDigitControl:TextBox
    {        
        const int WM_PASTE = 0x0302; //Сообщение "Вставка" (через к.м. и комбинацию клавиш)
        const int WM_CHAR = 0x0102; //Сообщение - нажатие алфавитно-цифровой клавиши

        [Description("Enable or disable negative number input"), 
        Category("Behavior"), DefaultValue(false)]
        public bool Negative { get; set; } //включает/отключает ввод отрицательных чисел
        [Description("Enable or disable fractional number input"),
        Category("Behavior"), DefaultValue(false)]
        public bool Fractional { get; set; } //включает/отключает ввод дробных чисел

        private char separator = '.';
        [Description("Decimal separator, may be '.' or ','"),
        Category("Format"), DefaultValue('.')] //разделитель дробной и целой части числа
        public char Separator 
        {
            get { return separator; }
            set
            {
                if ((value != '.') && (value != ','))
                {
                    throw new ArgumentOutOfRangeException("Separator",
                        "Value must be '.' or ','");
                }
                else
                {
                    separator = value;
                }
            }
        } 

        public override bool PreProcessMessage(ref Message msg)
        {
            if (msg.Msg == WM_CHAR)
            {
                //в была нажата комбинация клавиш
                if ((ModifierKeys != Keys.None)&&
                    (ModifierKeys != Keys.Shift)) return false;
                                
                //получаем char из кода символа в WParam
                char chr = (char)msg.WParam.ToInt32();

                if (chr == '\b') return false; //backspace

                //это цифры (ура, товарищи)
                if (chr >= '0' && chr <= '9')
                {
                    return false;
                }
                else
                {
                    //получаем текущую позицию курсора для вставки точки/минуса
                    int pos = this.SelectionStart;

                    //нажали минус, ввод отрицательных разрешен свойством Negative
                    if (chr == '-' && Negative)
                    {                        
                        if (this.Text.StartsWith("-")) //минус уже есть
                        {
                            this.Text = this.Text.Substring(1);//убираем
                            //ставим курсор на прежнюю позицию. 
                            //Т.е. на -1 от текущей, т.к. удалили 1 символ
                            this.SelectionStart = pos - 1;
                        }
                        else //минуса нет
                        {
                            this.Text = "-" + this.Text; //добавили
                            //переставили курсор
                            this.SelectionStart = pos + 1;
                        }
                        
                    } //конец ввод отрицательных

                    //ввод разделителя дробной части
                    //поле реагирует и на . и на ,
                    if ((chr == '.' || chr == ',') && Fractional)
                    {
                        //проверяем, чтоб в строке не было двух разделителей
                        if (this.Text.Contains(separator.ToString()))
                        {
                            return true;
                        }

                        //если поле пустое, добавляем 0 перед разделителем
                        if (this.Text == string.Empty)
                        {
                            this.Text = "0" + separator.ToString();
                            //ставим курсор в конец текста
                            this.SelectionStart = this.Text.Length;
                        }
                        else
                        {
                            //меняем WParam на код разделителя
                            msg.WParam = (IntPtr)separator;
                            
                            //проверяем, не поставили ли разделитель
                            //в начале текста
                            if (this.SelectionStart == 0)
                            {
                                //если поставили и текст начинается с -
                                //игнорируем нажатие, перед "-" 
                                //разделителя не бывает
                                if (this.Text.StartsWith("-")) return true;
                                
                                //добавляем лидирующий 0
                                this.Text = "0" + separator.ToString() 
                                    + this.Text;
                                this.SelectionStart = 2;
                                return true;
                            }
                            
                            //если курсор стоит после "-"
                            if ((this.SelectionStart == 1) &&
                                this.Text.StartsWith("-"))
                            {
                                //добавляем "-0," или "-0." к началу текста

                                this.Text = "-0" + separator.ToString() +
                                    this.Text.Substring(1);
                                this.SelectionStart = 3;

                                return true;
                            }
                            
                            return false;
                        }
                    }
                    return true;
                }
            }

            return base.PreProcessMessage(ref msg);
        }

        private bool IsDouble(string st)
        {
            st = st.Replace('.', separator);
            st = st.Replace(',', separator);
            NumberFormatInfo format = new NumberFormatInfo();
            format.NumberDecimalSeparator = separator.ToString();

            try
            {
                double d = Convert.ToDouble(st, format);
                return true;
            }
            catch
            {
                return false;
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_PASTE) //перехватываем сообщение "вставка"
            {
                //получаем строку из буфера обмена
                IDataObject obj = Clipboard.GetDataObject();
                string input = (string)obj.GetData(typeof(string));
                ulong tmpulong = 0;
                long tmplong = 0;

                if ((!Fractional) && (!Negative)) //только цифры
                {
                    //пытаемся конвертировать в беззнаковый long
                    if (!ulong.TryParse(input,out tmpulong))
                    {
                        //не получилось
                        m.Result = (IntPtr)0; //отменяем вставку
                        return;
                    }
                }
                
                //отрицательные и положительные целые
                if ((!Fractional) && (Negative))
                {
                    //пытаемся конвертировать в знаковый long
                    if (!long.TryParse(input,out tmplong))
                    {
                        //не получилось
                        m.Result = (IntPtr)0; //отменяем вставку
                        return;
                    }
                }

                //дробные
                if ((Fractional))
                {
                    //пытаемся конвертировать в double
                    if (!IsDouble(input))
                    {
                        //не получилось
                        m.Result = (IntPtr)0; //отменяем вставку
                        return;
                    }
                    
                    //заменяем разделитель на установленный в контроле
                    input = input.Replace('.', separator);
                    input = input.Replace(',', separator);

                    //добавляем лидирующий 0 если надо
                    if (input.StartsWith(separator.ToString()))
                    {
                        input = input.Replace(separator.ToString(),
                            "0" + separator.ToString());
                    }
                    if (input.StartsWith("-" + separator.ToString()))
                    {
                        input = input.Replace("-" + separator.ToString(),
                            "-0" + separator.ToString());
                    }

                    //дробные не отрицательные
                    if (!Negative)
                    {
                        if (input.StartsWith("-"))
                        {
                            m.Result = (IntPtr)0; //отменяем вставку
                            return;
                        }
                    }
                    
                    //меняем содержимое буфера обмена
                    Clipboard.SetText(input);
                }

                //вставка чисел целиком
                this.Text = string.Empty;
            }

            base.WndProc(ref m);
        }
        
    }
}
