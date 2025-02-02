using System.Collections.Generic;
using VkNet.Abstractions;
using VkNet.Model;
using VkNet.Model.Attachments;
using VkNet.Model.RequestParams.Notes;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc />
public partial class NotesCategory : INotesCategory
{
	/// <summary>
	/// API.
	/// </summary>
	private readonly IVkApiInvoke _vk;

	/// <summary>
	/// api vk.com
	/// </summary>
	/// <param name="vk">
	/// Api vk.com
	/// </param>
	public NotesCategory(VkApi vk) => _vk = vk;

	/// <inheritdoc />
	public long Add(NotesAddParams notesAddParams) => _vk.Call("notes.add",
		new()
		{
			{
				"title", notesAddParams.Title
			},
			{
				"text", notesAddParams.Text
			},
			{
				"privacy_view", notesAddParams.PrivacyView
			},
			{
				"privacy_comment", notesAddParams.PrivacyComment
			}
		});

	/// <inheritdoc />
	public long CreateComment(NotesCreateCommentParams createCommentParams) => _vk.Call("notes.createComment ",
		new()
		{
			{
				"note_id", createCommentParams.NoteId
			},
			{
				"owner_id", createCommentParams.OwnerId
			},
			{
				"reply_to", createCommentParams.ReplyTo
			},
			{
				"message", createCommentParams.Message
			}
		});

	/// <inheritdoc />
	public bool Delete(long noteId) => _vk.Call("notes.delete",
		new()
		{
			{
				"note_id", noteId
			}
		});

	/// <inheritdoc />
	public bool DeleteComment(NotesDeleteCommentParams deleteCommentParams) => _vk.Call("notes.deleteComment",
		new()
		{
			{
				"comment_id", deleteCommentParams.CommentId
			},
			{
				"owner_id", deleteCommentParams.OwnerId
			}
		});

	/// <inheritdoc />
	public bool Edit(NotesEditParams editParams) => _vk.Call("notes.edit",
		new()
		{
			{
				"note_id", editParams.NoteId
			},
			{
				"title", editParams.Title
			},
			{
				"text", editParams.Text
			},
			{
				"privacy_view", editParams.PrivacyView
			},
			{
				"privacy_comment", editParams.PrivacyComment
			}
		});

	/// <inheritdoc />
	public bool EditComment(NotesEditCommentParams editCommentParams) => _vk.Call("notes.editComment",
		new()
		{
			{
				"comment_id", editCommentParams.CommentId
			},
			{
				"owner_id", editCommentParams.OwnerId
			},
			{
				"message", editCommentParams.Message
			}
		});

	/// <inheritdoc />
	public IEnumerable<Note> Get(NotesGetParams notesGetParams) => _vk.Call("notes.get",
			new()
			{
				{
					"note_ids", notesGetParams.NoteIds
				},
				{
					"user_id", notesGetParams.UserId
				},
				{
					"offset", notesGetParams.Offset
				},
				{
					"count", notesGetParams.Count
				},
				{
					"sort", notesGetParams.Sort
				}
			})
		.ToReadOnlyCollectionOf<Note>(selector: x => x);

	/// <inheritdoc />
	public Note GetById(NotesGetByIdParams getByIdParams) => _vk.Call("notes.getById",
		new()
		{
			{
				"note_id", getByIdParams.NoteId
			},
			{
				"owner_id", getByIdParams.OwnerId
			},
			{
				"need_wiki", getByIdParams.IsNeedWiki
			}
		});

	/// <inheritdoc />
	public IEnumerable<CommentNote> GetComments(NotesGetCommentParams getCommentParams) => _vk.Call("notes.getComments",
			new()
			{
				{
					"note_id", getCommentParams.NoteId
				},
				{
					"owner_id", getCommentParams.OwnerId
				},
				{
					"sort", getCommentParams.Sort
				},
				{
					"offset", getCommentParams.Offset
				},
				{
					"count", getCommentParams.Count
				}
			})
		.ToReadOnlyCollectionOf<CommentNote>(selector: x => x);

	/// <inheritdoc />
	public bool RestoreComment(NotesRestoreCommentParams restoreCommentParams) => _vk.Call("notes.restoreComment",
		new()
		{
			{
				"comment_id", restoreCommentParams.CommentId
			},
			{
				"owner_id", restoreCommentParams.OwnerId
			}
		});
}