using System.Collections.Generic;
using System.Threading.Tasks;
using VkNet.Enums;
using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet.Model.Attachments;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc />
public partial class WallCategory
{
	/// <inheritdoc />
	public Task<WallGetObject> GetAsync(WallGetParams @params, bool skipAuthorization = false) =>
		TypeHelper.TryInvokeMethodAsync(func: () => Get(@params, skipAuthorization));

	/// <inheritdoc />
	public Task<WallGetCommentsResult> GetCommentsAsync(WallGetCommentsParams @params, bool skipAuthorization = false) =>
		TypeHelper.TryInvokeMethodAsync(func: () => GetComments(@params, skipAuthorization));

	/// <inheritdoc />
	public Task<WallGetObject> GetByIdAsync(IEnumerable<string> posts
											, bool? extended = null
											, long? copyHistoryDepth = null
											, ProfileFields fields = null
											, bool skipAuthorization = false) => TypeHelper.TryInvokeMethodAsync(func: () =>
		GetById(posts,
			extended,
			copyHistoryDepth,
			fields,
			skipAuthorization));

	/// <inheritdoc />
	public Task<long> PostAsync(WallPostParams @params) => TypeHelper.TryInvokeMethodAsync(func: () => Post(@params: @params));

	/// <inheritdoc />
	public Task<RepostResult> RepostAsync(string @object, string message, long? groupId, bool markAsAds) => TypeHelper.TryInvokeMethodAsync(
		func: () =>
			Repost(@object, message, groupId, markAsAds));

	/// <inheritdoc />
	public Task<long> EditAsync(WallEditParams @params) => TypeHelper.TryInvokeMethodAsync(func: () => Edit(@params: @params));

	/// <inheritdoc />
	public Task<bool> DeleteAsync(long? ownerId = null, long? postId = null) =>
		TypeHelper.TryInvokeMethodAsync(func: () => Delete(ownerId, postId));

	/// <inheritdoc />
	public Task<bool> RestoreAsync(long? ownerId = null, long? postId = null) =>
		TypeHelper.TryInvokeMethodAsync(func: () => Restore(ownerId, postId));

	/// <inheritdoc />
	public Task<long> CreateCommentAsync(WallCreateCommentParams @params) =>
		TypeHelper.TryInvokeMethodAsync(func: () => CreateComment(@params: @params));

	/// <inheritdoc />
	public Task<bool> DeleteCommentAsync(long? ownerId, long commentId) =>
		TypeHelper.TryInvokeMethodAsync(func: () => DeleteComment(ownerId, commentId));

	/// <inheritdoc />
	public Task<bool> RestoreCommentAsync(long commentId, long? ownerId) =>
		TypeHelper.TryInvokeMethodAsync(func: () => RestoreComment(commentId, ownerId));

	/// <inheritdoc />
	public Task<WallGetObject> SearchAsync(WallSearchParams @params, bool skipAuthorization = false) => TypeHelper.TryInvokeMethodAsync(
		func: () =>
			Search(@params, skipAuthorization));

	/// <inheritdoc />
	public Task<WallGetObject> GetRepostsAsync(long? ownerId
												, long? postId
												, long? offset
												, long? count
												, bool skipAuthorization = false) => TypeHelper.TryInvokeMethodAsync(func: () =>
		GetReposts(ownerId, postId, offset, count, skipAuthorization));

	/// <inheritdoc />
	public Task<bool> PinAsync(long postId, long? ownerId = null) => TypeHelper.TryInvokeMethodAsync(func: () => Pin(postId, ownerId));

	/// <inheritdoc />
	public Task<bool> UnpinAsync(long postId, long? ownerId = null) => TypeHelper.TryInvokeMethodAsync(func: () => Unpin(postId, ownerId));

	/// <inheritdoc />
	public Task<bool> EditCommentAsync(long commentId
										, string message
										, long? ownerId = null
										, IEnumerable<MediaAttachment> attachments = null) => TypeHelper.TryInvokeMethodAsync(func: () =>
		EditComment(commentId, message, ownerId, attachments));

	/// <inheritdoc />
	public Task<bool> ReportPostAsync(long ownerId, long postId, ReportReason? reason = null) =>
		TypeHelper.TryInvokeMethodAsync(func: () => ReportPost(ownerId, postId, reason));

	/// <inheritdoc />
	public Task<bool> ReportCommentAsync(long ownerId, long commentId, ReportReason? reason) => TypeHelper.TryInvokeMethodAsync(func: () =>
		ReportComment(ownerId, commentId, reason));

	/// <inheritdoc />
	public Task<bool> EditAdsStealthAsync(EditAdsStealthParams @params) =>
		TypeHelper.TryInvokeMethodAsync(func: () => EditAdsStealth(@params: @params));

	/// <inheritdoc />
	public Task<long> PostAdsStealthAsync(PostAdsStealthParams @params) =>
		TypeHelper.TryInvokeMethodAsync(func: () => PostAdsStealth(@params: @params));

	/// <inheritdoc />
	public Task<bool> OpenCommentsAsync(long ownerId, long postId) =>
		TypeHelper.TryInvokeMethodAsync(func: () => OpenComments(ownerId, postId));

	/// <inheritdoc />
	public Task<bool> CloseCommentsAsync(long ownerId, long postId) =>
		TypeHelper.TryInvokeMethodAsync(func: () => CloseComments(ownerId, postId));

	/// <inheritdoc />
	public Task<bool> CheckCopyrightLinkAsync(string link) => TypeHelper.TryInvokeMethodAsync(func: () => CheckCopyrightLink(link));

	/// <inheritdoc />
	public Task<WallGetCommentResult> GetCommentAsync(int ownerId, int commentId, bool? extended = null, string fields = null,
													bool skipAuthorization = false) => TypeHelper.TryInvokeMethodAsync(func: () =>
		GetComment(ownerId, commentId, extended, fields, skipAuthorization));
}