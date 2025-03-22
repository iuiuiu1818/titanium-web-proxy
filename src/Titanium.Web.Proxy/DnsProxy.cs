using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Titanium.Web.Proxy
{
    public static class DnsProxy
    {

        public static Dictionary<string, IPAddress> MyDnsDic { get; private set; } = new Dictionary<string, IPAddress>();

        public static Task<IPAddress[]> GetHostAddressesAsync(string hostNameOrAddress)
        {
            if (DnsProxy.MyDnsDic.ContainsKey(hostNameOrAddress))
            {
                return Task.FromResult<IPAddress[]>(new IPAddress[] { DnsProxy.MyDnsDic[hostNameOrAddress] });
            }
            try
            {
                Console.WriteLine(hostNameOrAddress);
                return Dns.GetHostAddressesAsync(hostNameOrAddress);
            }
            catch (Exception ex)
            {
                throw new Exception("Dns Error" + hostNameOrAddress);
            }
        }
    }
}
