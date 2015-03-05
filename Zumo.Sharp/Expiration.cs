using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zumo.Sharp.Authentication
{
	public class ExpirationBuilder
	{
		public double GetExpirationDateUnix(int expiryPeriodInMinutes)
		{
			return Math.Round((DateTime.Now.AddMinutes(expiryPeriodInMinutes).ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds);
		}
	}
}
