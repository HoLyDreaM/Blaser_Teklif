using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for FormAciklamalariIslem
/// </summary>
public class FormAciklamalariIslem : FormAciklamalariDB
{
	public NFormAciklamasi FormAciklamasiGetir() 
	{
		var result = base.frmAciklamalariniGetir();
		if (!result.BasariliMi)
		{
			return new NFormAciklamasi
			{
				BasariliMi = false
			};
		}
		else {
			DataRow dr = (result.Veri as DataTable).Rows[0];         
			return new NFormAciklamasi
			{
				UstBaslik1 = dr[1].ToString(),
				UstBaslik2 = dr[2].ToString(),
				UstBaslik3 = dr[3].ToString(),
				UstBaslik4 = dr[4].ToString(),

                AltBaslik1 = dr[5].ToString(),
                AltBaslik2 = dr[6].ToString(),
                AltBaslik3 = dr[7].ToString(),
                AltBaslik4 = dr[8].ToString(),

				BasariliMi = true
			};
		}
	}

	public NIslemSonuc frmAciklamalariniKaydet(NFormAciklamasi NFormAciklamasi) {
		return base.frmAciklamalariniKaydet(NFormAciklamasi);
	}
}