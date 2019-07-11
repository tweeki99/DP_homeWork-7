using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DpHw_7.ISP
{
    // Интерфейс для звонка
    interface ICall
    {
        void Call();
    }
    // Интерфейс для фото
    interface IPhoto
    {
        void TakePhoto();
    }

    // Камера может делать снимки, но не предназначена для звонков.
    // Поэтому реализует только интерфейс IPhoto
    class Camera : IPhoto
    {
        public void TakePhoto()
        {
            Console.WriteLine("Фотографируем с помощью фотокамеры");
        }
    }

    // Похожая логика и с домашним телефоном, только наоборот.
    // Звонить можно, а снимать нет
    class HomePhone : ICall
    {
        public void Call()
        {
            Console.WriteLine("Звоним по домашнему телефону");
        }
    }

    // Но смартфон в свою очередь может принимать звонки иделать снимки
    // Поэтому реализует оба интерфейса
    class MobilePhone : ICall, IPhoto
    {
        public void Call()
        {
            Console.WriteLine("Звоним по смартфону");
        }
        public void TakePhoto()
        {
            Console.WriteLine("Фотографируем с помощью смартфона");
        }
    }
    
    // Таким образом фотограф не сможет сделать снимок, например, с домашнего телефона 
    // так как он для этого не предназначен и не реализует нужный интерфейс
    class Photograph
    {
        public void TakePhoto(IPhoto photoMaker)
        {
            photoMaker.TakePhoto();
        }

        public void Call(ICall photoMaker)
        {
            photoMaker.Call();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Photograph photograph = new Photograph();
            MobilePhone mobilePhone = new MobilePhone();
            HomePhone homePhone = new HomePhone();
            Camera camera = new Camera();

            photograph.TakePhoto(mobilePhone);
            photograph.TakePhoto(camera);

            photograph.Call(mobilePhone);
            photograph.Call(homePhone);
        }
    }
}
