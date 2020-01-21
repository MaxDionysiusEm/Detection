﻿using Wangkanai.Detection.Models;
using Xunit;

namespace Wangkanai.Detection.Services
{
    public class PlatformServiceTest
    {
        [Theory]
        [InlineData(Processor.x64, "Mozilla/5.0 (Windows NT x.y; Win64; x64; rv:10.0) Gecko/20100101 Firefox/10.0")]
        [InlineData(Processor.x64, "Mozilla/5.0 (Windows NT 10.0; WOW64; Trident/7.0; rv:11.0) like Gecko")]
        [InlineData(Processor.x86, "Mozilla/5.0 (Windows x86; rv:19.0) Gecko/20100101 Firefox/19.0")]
        [InlineData(Processor.ARM, "Mozilla/5.0 (Windows NT 10.0; ARM; RM-1096) AppleWebKit/537.36 (KHTML like Gecko) Chrome/51.0.2704.79 Safari/537.36 Edge/14.14393")]
        public void Windows(Processor processor, string agent)
        {
            var os = OperatingSystem.Windows;
            var service = MockService.CreateService(agent);
            var resolver = new PlatformService(service);
            Assert.Equal(os, resolver.OperatingSystem);
            Assert.Equal(processor, resolver.Processor);
        }

        [Theory]
        [InlineData("Mozilla/5.0 (Android 4.4; Mobile; rv:41.0) Gecko/41.0 Firefox/41.0")]
        [InlineData("Mozilla/5.0 (Linux; Android 7.0; SM-T585 Build/NRD90M) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36")]
        [InlineData("Mozilla/5.0 (Linux; Android 4.4.2); Nexus 5 Build/KOT49H) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/33.0.1750.117 Mobile Safari/537.36 OPR/20.0.1396.72047")]
        public void Android(string agent)
        {
            var os = OperatingSystem.Android;
            var processor = Processor.ARM;
            var service = MockService.CreateService(agent);
            var resolver = new PlatformService(service);
            Assert.Equal(os, resolver.OperatingSystem);
            Assert.Equal(processor, resolver.Processor);
        }

        [Theory]
        [InlineData(Processor.x64, "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_13_6) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/13.0 Safari/605.1.15")]
        [InlineData(Processor.x64, "Mozilla/5.0 (Macintosh; Intel Mac OS X x.y; rv:10.0) Gecko/20100101 Firefox/10.0")]
        [InlineData(Processor.Others, "Mozilla/5.0 (Macintosh; PPC Mac OS X x.y; rv:10.0) Gecko/20100101 Firefox/10.0")]
        public void Mac(Processor processor, string agent)
        {
            var os = OperatingSystem.Mac;
            var service = MockService.CreateService(agent);
            var resolver = new PlatformService(service);
            Assert.Equal(os, resolver.OperatingSystem);
            Assert.Equal(processor, resolver.Processor);
        }

        [Theory]
        [InlineData(Processor.x64, "Mozilla/5.0 (X11; U; Linux x86_64; en-US; rv:1.9.2.22) Gecko/20110904 Red Hat/3.6-1.el5_7 Firefox/3.6.22")]
        [InlineData(Processor.x86, "Mozilla/5.0 (X11; Red Hat Enterprise; Linux i686; rv:41.0) Gecko/20100101 Firefox/41.0")]
        [InlineData(Processor.ARM, "Mozilla/5.0 (Linux arm) Gecko/20110318 Firefox/4.0b13pre Fennec/4.0")]
        public void Linux(Processor processor, string agent)
        {
            var os = OperatingSystem.Linux;
            var service = MockService.CreateService(agent);
            var resolver = new PlatformService(service);
            Assert.Equal(os, resolver.OperatingSystem);
            Assert.Equal(processor, resolver.Processor);
        }

        [Theory]
        [InlineData(Processor.x86, "Mozilla/4.79 [en] (X11; U; SunOS 5.10 i86pc)")]
        [InlineData(Processor.Others, "Mozilla/5.0 (X11; U; SunOS sun4u; en-US; rv:1.8.1.11) Gecko/20080118 Firefox/2.0.0.11")]
        public void Others(Processor processor, string agent)
        {
            var os = OperatingSystem.Others;
            var service = MockService.CreateService(agent);
            var resolver = new PlatformService(service);
            Assert.Equal(os, resolver.OperatingSystem);
            Assert.Equal(processor, resolver.Processor);
        }
    }
}
