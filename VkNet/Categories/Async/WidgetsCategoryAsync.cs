using System.Threading.Tasks;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc />
public partial class WidgetsCategory
{
	/// <inheritdoc />
	public Task<VkCollection<Comment>> GetCommentsAsync(GetCommentsParams getCommentsParams) =>
		TypeHelper.TryInvokeMethodAsync(func: () => GetComments(getCommentsParams: getCommentsParams));

	/// <inheritdoc />
	public Task<VkCollection<WidgetPage>> GetPagesAsync(long? widgetApiId = null
														, string order = null
														, string period = null
														, ulong? offset = null
														, ulong? count = null) => TypeHelper.TryInvokeMethodAsync(func: () =>
		GetPages(widgetApiId, order, period, offset, count));
}