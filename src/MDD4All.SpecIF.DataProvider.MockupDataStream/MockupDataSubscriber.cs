using MDD4All.SpecIF.DataModels;
using MDD4All.SpecIF.DataProvider.Contracts.DataStreams;
using System;
using System.Collections.Generic;
using System.Threading;

namespace MDD4All.SpecIF.DataProvider.MockupDataStream
{
    public class MockupDataSubscriber : ISpecIfDataSubscriber
    {
        public event SpecIfDataReceivedEventHandler SpecIfDataReceived;

        private Timer _timer5s;

        public MockupDataSubscriber()
        {
            _timer5s = new Timer(OnTimerElapsed, null, 3000, 5000);
        }

        private void OnTimerElapsed(object state)
        {
            if (SpecIfDataReceived != null)
            {
                SpecIfDataReceived.Invoke(this, MockupResources);
            }
        }

        private List<Resource> MockupResources
        {
            get
            {
                List<Resource> result = new List<Resource>
                {
                    new Resource
                    {
                        Class = new Key("RC-Requirement", "1.1"),
                        Properties = new List<Property>
                        {
                            new Property
                            {
                                Class = new Key("PC-Name", "1.1"),
                                Value = "Eine Anforderung"
                            }
                        }
                    }
                };

                return result;
            }
        }



    }
}
