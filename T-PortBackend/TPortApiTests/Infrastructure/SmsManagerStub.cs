using System;
using System.Collections.Generic;
using TPort.Services;

namespace TPortApiTests.Infrastructure
{
	public class SmsManagerStub : ISmsManager
	{
		public IReadOnlyDictionary<string, string> SentMessages => _sentMessages;

		public void SendMessage(string phoneNumber, string message)
		{
			if (phoneNumber == null) throw new ArgumentNullException(nameof(phoneNumber));

			if (message == null) throw new ArgumentNullException(nameof(message));

			_sentMessages.Add(phoneNumber, message);
		}

		private readonly Dictionary<string, string> _sentMessages = new Dictionary<string, string>();
	}
}