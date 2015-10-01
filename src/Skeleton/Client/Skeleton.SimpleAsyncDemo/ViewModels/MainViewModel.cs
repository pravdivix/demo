using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Skeleton.Client.Core;
using Skeleton.Client.Core.Commands.Async;

namespace Skeleton.SimpleAsyncDemo.ViewModels
{
	internal sealed class MainViewModel : ViewModel
	{
		private int byteCount;
		private string url;

		public MainViewModel()
		{
			Url = "http://www.example.com/";
			CountUrlBytesCommand = new AsyncCommand<int>(token => MyService.DownloadAndCountBytesAsync(Url, token));
		}

		public int ByteCount
		{
			get { return byteCount; }
			private set { SetProperty(ref byteCount, value); }
		}

		public IAsyncCommand CountUrlBytesCommand { get; private set; }

		public string Url
		{
			get { return url; }
			set { SetProperty(ref url, value); }
		}

		private static class MyService
		{
			public static async Task<int> DownloadAndCountBytesAsync(string url, CancellationToken token = new CancellationToken())
			{
				await Task.Delay(TimeSpan.FromSeconds(3), token).ConfigureAwait(false);

				HttpClient client = new HttpClient();

				using (HttpResponseMessage response = await client.GetAsync(url, token).ConfigureAwait(false))
				{
					byte[] data = await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
					return data.Length;
				}
			}
		}
	}
}
