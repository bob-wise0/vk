using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using VkNet.Enums;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.Attachments;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc />
public partial class DocsCategory
{
	/// <inheritdoc />
	public Task<VkCollection<Document>> GetAsync(int? count = null
												, int? offset = null
												, long? ownerId = null
												, DocFilter? type = null) => TypeHelper.TryInvokeMethodAsync(func: () =>
		Get(count, offset, ownerId, type));

	/// <inheritdoc />
	public Task<ReadOnlyCollection<Document>> GetByIdAsync(IEnumerable<Document> docs) =>
		TypeHelper.TryInvokeMethodAsync(func: () => GetById(docs: docs));

	/// <inheritdoc />
	public Task<UploadServerInfo> GetUploadServerAsync(long? groupId = null) =>
		TypeHelper.TryInvokeMethodAsync(func: () => GetUploadServer(groupId: groupId));

	/// <inheritdoc />
	public Task<UploadServerInfo> GetWallUploadServerAsync(long? groupId = null) =>
		TypeHelper.TryInvokeMethodAsync(func: () => GetWallUploadServer(groupId: groupId));

	/// <inheritdoc />
	public Task<ReadOnlyCollection<Attachment>> SaveAsync(string file, string title, string tags = null) =>
		TypeHelper.TryInvokeMethodAsync(func: () => Save(file, title, tags));

	/// <inheritdoc />
	[Obsolete(ObsoleteText.CaptchaNeeded, true)]
	public Task<ReadOnlyCollection<Attachment>> SaveAsync(string file
														, string title
														, string tags = null
														, long? captchaSid = null
														, string captchaKey = null) => TypeHelper.TryInvokeMethodAsync(func: () =>
		Save(file, title, tags, captchaSid, captchaKey));

	/// <inheritdoc />
	public Task<bool> DeleteAsync(long ownerId, long docId) => TypeHelper.TryInvokeMethodAsync(func: () => Delete(ownerId, docId));

	/// <inheritdoc />
	public Task<long> AddAsync(long ownerId, long docId, string accessKey = null) =>
		TypeHelper.TryInvokeMethodAsync(func: () => Add(ownerId, docId, accessKey));

	/// <inheritdoc />
	[Obsolete(ObsoleteText.CaptchaNeeded, true)]
	public Task<long> AddAsync(long ownerId
								, long docId
								, string accessKey = null
								, long? captchaSid = null
								, string captchaKey = null) => TypeHelper.TryInvokeMethodAsync(func: () =>
		Add(ownerId, docId, accessKey, captchaSid, captchaKey));

	/// <inheritdoc />
	public Task<VkCollection<DocumentType>> GetTypesAsync(long ownerId) =>
		TypeHelper.TryInvokeMethodAsync(func: () => GetTypes(ownerId: ownerId));

	/// <inheritdoc />
	public Task<VkCollection<Document>> SearchAsync(string query, bool searchOwn, long? count = null, long? offset = null) =>
		TypeHelper.TryInvokeMethodAsync(func: () =>
			Search(query, searchOwn, count, offset));

	/// <inheritdoc />
	public Task<bool> EditAsync(long ownerId, long docId, string title, IEnumerable<string> tags) => TypeHelper.TryInvokeMethodAsync(
		func: () =>
			Edit(ownerId, docId, title, tags));

	/// <inheritdoc />
	public Task<UploadServerInfo> GetMessagesUploadServerAsync(long? peerId = null, DocMessageType type = null) =>
		TypeHelper.TryInvokeMethodAsync(func: () => GetMessagesUploadServer(peerId, type));
}