/*int sepctr = 0; //счетчик разделителей
                                                
                for (int i = 0; i < input.Length;i++ )
                {
                    if (i == 0) //проверяем первый символ на минус
                    {
                        //минус и разрешен ввод отрицательных чисел разрешен
                        if (input[i] == '-' && Negative) continue;
                    }

                    //в строке присутствует разделитель, 
                    //ввод дробных чисел разрешен
                    if ((input[i] == '.' || input[i] == ',') && Fractional)
                    {
                        sepctr++; //подсчет разделителей
                        
                        //больше 2 разделителей
                        if (sepctr > 1)
                        {
                            m.Result = (IntPtr)0; //отменяем вставку
                            return;
                        }
                        else continue;
                    }

                    //если символ не цифра
                    if (!char.IsDigit(input[i]))
                    {
                        m.Result = (IntPtr)0; //отменяем вставку
                        return;
                    }
                }
                //не-цифр не найдено

                //вставка чисел целиком
                this.Text = string.Empty;
                
                if (Fractional)
                {
                    //заменяем возможные разделители на установленный в контроле
                    input = input.Replace('.', separator);
                    input = input.Replace(',', separator);
                    
                    //меняем содержимое буфера
                    Clipboard.SetText(input);
                }*/