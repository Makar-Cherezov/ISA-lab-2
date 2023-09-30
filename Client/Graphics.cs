using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Client
{
    public static class Graphics
    {
        public static string Logo { get; set; }
        public static string Exit { get; set; }
        public static string Line { get; set; }
        
        public static string GetLogo()
        {
            Logo = File.ReadAllText(@"C:\Учёба\Архитектура ИС\ЛР 1\ЛР 1 консоль\Logo.txt");
            return Logo;
        }

        public static string GetExit()
        {
            Exit = File.ReadAllText(@"C:\Учёба\Архитектура ИС\ЛР 1\ЛР 1 консоль\ExitText.txt");
            return Exit;
        }
        public static string GetLine()
        {
            Line = File.ReadAllText(@"C:\Учёба\Архитектура ИС\ЛР 1\ЛР 1 консоль\Line.txt");
            return Line;
        }
            
    }
    
}
