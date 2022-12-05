using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDemo.GetMovieService
{
    public enum ResponseType
    {

        #region Hata Kodları

        EklenirkenHata = 100,
        DbHatasi = 101,
        VeriEklerkenHataVerdi = 102,
        KontrolEdinizHataOlustu=103,

        #endregion




        #region Başarılı Kodları

        Basarili = 201,
        DataEkendi = 202,

        DataGüncellendi=301,

        DataSilindi=351,

        #endregion


        #region Uyarı mesajları

        DataMevcut=401,


        #endregion




    }
}
