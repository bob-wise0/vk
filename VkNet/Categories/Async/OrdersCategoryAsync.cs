using System.Collections.Generic;
using System.Threading.Tasks;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc/>
public partial class OrdersCategory
{
	/// <inheritdoc/>
	public Task<bool> CancelSubscriptionAsync(ulong userId, ulong subscriptionId, bool? pendingCancel = null) =>
		TypeHelper.TryInvokeMethodAsync(() => CancelSubscription(userId, subscriptionId, pendingCancel));

	/// <inheritdoc/>
	public Task<OrderState> ChangeStateAsync(ulong orderId, OrderStateAction action, ulong? appOrderId = null, bool? testMode = null) =>
		TypeHelper.TryInvokeMethodAsync(() => ChangeState(orderId, action, appOrderId, testMode));

	/// <inheritdoc/>
	public Task<IEnumerable<Order>> GetAsync(ulong? offset = null, ulong? count = null, bool? testMode = null) =>
		TypeHelper.TryInvokeMethodAsync(() => Get(offset, count, testMode));

	/// <inheritdoc/>
	public Task<IEnumerable<VotesAmount>> GetAmountAsync(ulong userId, IEnumerable<string> votes) =>
		TypeHelper.TryInvokeMethodAsync(() => GetAmount(userId, votes));

	/// <inheritdoc/>
	public Task<IEnumerable<Order>> GetByIdAsync(IEnumerable<ulong> orderIds = null, bool? testMode = null) =>
		TypeHelper.TryInvokeMethodAsync(() => GetById(orderIds, testMode));

	/// <inheritdoc/>
	public Task<SubscriptionItem> GetUserSubscriptionByIdAsync(ulong userId, ulong subscriptionId) =>
		TypeHelper.TryInvokeMethodAsync(() => GetUserSubscriptionById(userId, subscriptionId));

	/// <inheritdoc/>
	public Task<IEnumerable<SubscriptionItem>> GetUserSubscriptionsAsync(ulong userId) =>
		TypeHelper.TryInvokeMethodAsync(() => GetUserSubscriptions(userId));

	/// <inheritdoc/>
	public Task<bool> UpdateSubscriptionAsync(ulong userId, ulong subscriptionId, ulong price) =>
		TypeHelper.TryInvokeMethodAsync(() => UpdateSubscription(userId, subscriptionId, price));
}