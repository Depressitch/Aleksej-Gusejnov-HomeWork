using System;
using System.Collections.Generic;
using System.Text;


public class MyString
{
    public char[] Text { get; private set; }
    public int Length => Text.Length;

    //все инициализации
    #region constructors
    public MyString(char[] value) //инициализация передачей значения массива
    {
        Text = new char[value.Length];
        for (int i = 0; i < Length; i++)
            Text[i] = value[i];
    }
    public MyString(char value) //инициализация одним элементом
    {
        Text = new char[1];
        Text[0] = value;
    }
    public MyString(ReadOnlySpan<char> value) //инициализация коллекцией char'ов
    {
        Text = new char[value.Length];
        for (int i = 0; i < Length; i++)
            Text[i] = value[i];
    }
    public MyString()
    {
        Text = new char[0];
    }
    #endregion 

    #region methods
    public bool Contains(MyString str)
    {
        for (int i = 0; i <= Length - str.Length; i++)
        {
            bool wrong = false;
            for (int j = 0; j < str.Length; j++)
            {
                if (Text[i + j] != str[j])
                {
                    wrong = true;
                    break;
                }
            }
            if (wrong)
                continue;
            return true;
        }
        return false;
    }//проверка на содержание
    public void ToLower()
    {
        for (int i = 0; i < Length; i++)
        {
            Text[i] = char.ToLower(Text[i]);
        }
    }//перевод строки в нижний регистр
    public int IndexOf(char chr)
    {
        for (int i = 0; i < Length; i++)
        {
            if (Text[i] == chr)
                return i;
        }
        return -1;
    }//поиск символа 
    public int IndexOf(char chr, int index)
    {
        int index = -1;
        for (; index < Length; index++)
        {
            if (Text[index] == chr)
                return index;
        }
        return index;
    }//поиск символа начиная с какого-то индекса

    #endregion

    #region important
    public static MyString operator +(MyString FirstText, MyString SecondText)
    {
        char[] NewText = new char[FirstText.Length + SecondText.Length];
        for (int i = 0; i < FirstText.Length; i++)
        {
            NewText[i] = FirstText[i];
        }//добавляем элементы первой строки
        for (int i = 0; i < SecondText.Length; i++)
        {
            NewText[i + FirstText.Length] = SecondText[i];
        }//добавляем элементы второй строки
        return new MyString(NewText);
    }//обозначение работы оператора сложения
    public override string ToString()
    {
        string str = new string (Text);
        return str;
    }//перегрузка метода конвертирования в string
    public char this[int index]
    {
        get
        {
            while (index < 0)
                index += Length;
            while (index >= Length)
                index -= Length;

            return Text[index];
        }
        set
        {
            while (index < 0)
                index += Length;
            while (index >= Length)
                index -= Length;
            Text[index] = value;
        }
    }//индекскатор
    #endregion
}
