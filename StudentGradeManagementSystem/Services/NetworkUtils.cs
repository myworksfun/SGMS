using System;
using System.Net;
using System.Net.Sockets;

namespace StudentGradeManagementSystem.Services
{
    /// <summary>
    /// 网络工具类，提供网络相关功能
    /// </summary>
    public static class NetworkUtils
    {
        /// <summary>
        /// 获取本地IP地址
        /// </summary>
        /// <returns>本地IP地址</returns>
        public static string GetLocalIPAddress()
        {
            try
            {
                var host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (var ip in host.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        // 检查是否为回环地址
                        if (ip.ToString() != "127.0.0.1" && !ip.ToString().StartsWith("127."))
                        {
                            return ip.ToString();
                        }
                    }
                }
                return "127.0.0.1";
            }
            catch
            {
                return "127.0.0.1";
            }
        }
    }
}