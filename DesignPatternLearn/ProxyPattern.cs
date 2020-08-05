using System.IO;
using System;
/// <summary>
/// 代理模式
/// </summary>
public class ProxyPattern 
{
    public interface IImage
    {
        void Display();
    }

    public class RealImage : IImage
    {
        private string _fileName;

        public RealImage(string fileName)
        {
            _fileName = fileName;
            LoadFromDisk(fileName);
        }

        public void Display()
        {
            Console.WriteLine("displaying" + _fileName);
        }

        private void LoadFromDisk(string fileName)
        {
            Console.WriteLine("Loading" + fileName);
        }

        public class ProxyImage : IImage
        {
            private RealImage _realImage;
            private string _fileName;

            public ProxyImage(string fileName)
            {
                _fileName = fileName;
            }

            public void Display()
            {
                if (_realImage == null)
                {
                    _realImage = new RealImage(_fileName);
                }
                _realImage.Display();
            }
        }

        public void Main()
        {
            IImage image = new ProxyImage("test_img_01.jpg");

            // 图像将从磁盘加载
            image.Display();
            // 图像不需要从磁盘加载  缓存了
            image.Display();
        }
    }
}
