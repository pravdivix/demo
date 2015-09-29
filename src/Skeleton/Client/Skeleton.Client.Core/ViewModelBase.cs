namespace Skeleton.Client.Core
{
	public abstract class ViewModelBase<TModel> : ViewModel
	{
		private TModel model;

		public TModel Model
		{
			get { return model; }
			set { SetProperty(ref model, value); }
		}
	}
}