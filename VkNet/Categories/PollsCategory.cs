﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using VkNet.Abstractions;
using VkNet.Model;
using VkNet.Model.Attachments;
using VkNet.Model.RequestParams;
using VkNet.Model.RequestParams.Polls;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc />
public partial class PollsCategory : IPollsCategory
{
	/// <summary>
	/// API.
	/// </summary>
	private readonly IVkApiInvoke _vk;

	/// <summary>
	/// Методы для работы с опросами.
	/// </summary>
	/// <param name="vk"> API. </param>
	public PollsCategory(IVkApiInvoke vk) => _vk = vk;

	/// <inheritdoc />
	public Poll GetById(PollsGetByIdParams @params) => _vk.Call("polls.getById", new()
	{
		{
			"owner_id", @params.OwnerId
		},
		{
			"is_board", @params.IsBoard
		},
		{
			"poll_id", @params.PollId
		}
	});

	/// <inheritdoc />
	public bool Edit(PollsEditParams @params) => _vk.Call("polls.edit", new()
	{
		{
			"owner_id", @params.OwnerId
		},
		{
			"poll_id", @params.PollId
		},
		{
			"question", @params.Question
		},
		{
			"add_answers", Utilities.SerializeToJson(@object: @params.AddAnswers)
		},
		{
			"edit_answers", Utilities.SerializeToJson(@object: @params.EditAnswers)
		},
		{
			"delete_answers", Utilities.SerializeToJson(@object: @params.DeleteAnswers)
		}
	});

	/// <inheritdoc />
	public bool AddVote(PollsAddVoteParams @params) => _vk.Call("polls.addVote", new()
	{
		{
			"owner_id", @params.OwnerId
		},
		{
			"is_board", @params.IsBoard
		},
		{
			"poll_id", @params.PollId
		},
		{
			"answer_id", @params.AnswerId
		}
	});

	/// <inheritdoc />
	public bool DeleteVote(PollsDeleteVoteParams @params) => _vk.Call("polls.deleteVote", new()
	{
		{
			"owner_id", @params.OwnerId
		},
		{
			"is_board", @params.IsBoard
		},
		{
			"poll_id", @params.PollId
		},
		{
			"answer_id", @params.AnswerId
		}
	});

	/// <inheritdoc />
	public VkCollection<PollAnswerVoters> GetVoters(PollsGetVotersParams @params)
	{
		object FormatList(IList<long> answersIds)
		{
			if (answersIds == null)
			{
				return null;
			}

			var stringBuilder = new StringBuilder();

			for (var i = 0; i < answersIds.Count; i++)
			{
				stringBuilder.Append(value: answersIds[index: i]);

				if (i + 1 < answersIds.Count)
				{
					stringBuilder.Append(value: ',');
				}
			}

			return stringBuilder.ToString();
		}

		return _vk.Call("polls.getVoters", new()
			{
				{
					"owner_id", @params.OwnerId
				},
				{
					"is_board", @params.IsBoard
				},
				{
					"poll_id", @params.PollId
				},
				{
					"answer_ids", FormatList(answersIds: @params.AnswersIds)
				},
				{
					"friends_only", @params.FriendsOnly
				},
				{
					"offset", @params.Offset
				},
				{
					"count", @params.Count
				},
				{
					"fields", @params.Fields
				},
				{
					"name_case", @params.NameCase
				}
			})
			.ToVkCollectionOf<PollAnswerVoters>(x => x);
	}

	/// <inheritdoc />
	public Poll Create(PollsCreateParams @params) => _vk.Call("polls.create", new()
	{
		{
			"question", @params.Question
		},
		{
			"is_anonymous", @params.IsAnonymous
		},
		{
			"is_multiple", @params.IsMultiple
		},
		{
			"end_date", @params.EndDate
		},
		{
			"owner_id", @params.OwnerId
		},
		{
			"add_answers", Utilities.SerializeToJson(@params.AddAnswers)
		},
		{
			"photo_id", @params.PhotoId
		},
		{
			"background_id", @params.BackgroundId
		}
	});

	/// <inheritdoc />
	public ReadOnlyCollection<GetBackgroundsResult> GetBackgrounds() => _vk.Call<ReadOnlyCollection<GetBackgroundsResult>>(
		"polls.getBackgrounds",
		new());

	/// <inheritdoc />
	public PhotoUploadServer GetPhotoUploadServer(long ownerId) => _vk.Call<PhotoUploadServer>("polls.getPhotoUploadServer",
		new()
		{
			{
				"owner_id", ownerId
			}
		});

	/// <inheritdoc />
	public SavePhotoResult SavePhoto(SavePhotoParams @params) => _vk.Call<SavePhotoResult>("polls.savePhoto",
		new()
		{
			{
				"photo", @params.Photo
			},
			{
				"hash", @params.Hash
			}
		});
}