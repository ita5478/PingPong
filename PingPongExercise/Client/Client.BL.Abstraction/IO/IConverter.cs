using System;

namespace Client.BL.Abstraction
{
	public interface IConverter<in Tinput, out Toutput>
	{
		Toutput Convert(Tinput input);
	}
}
