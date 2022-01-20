using System;

namespace Common.Abstractions.IO
{
	public interface IConverter<Tinput, Toutput>
	{
		Toutput ConvertTo(Tinput input);

		Tinput ConvertFrom(Toutput input);
	}
}
