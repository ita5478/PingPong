using System;

namespace Client.BL.Abstraction
{
	public interface IConverter<Tinput, Toutput>
	{
		Toutput ConvertTo(Tinput input);

		Tinput ConvertFrom(Toutput input);
	}
}
