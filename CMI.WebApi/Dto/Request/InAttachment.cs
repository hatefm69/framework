using FIS.Tools;
using FIS.Tools.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace CMI.WebApi.Dto.Request
{
	public class InAttachment : InputsValidator<InAttachment>
	{
		// Properties.
		/// <summary>
		/// شناسه
		/// </summary>
		[Required(ErrorMessage = "شناسه را وارد نمایید")]
		[Range(long.MinValue, long.MaxValue, ErrorMessage = "محدوده مقدار شناسه صحیح نمی باشد")]
		public long? Id { get; set; }

		/// <summary>
		/// عنوان
		/// </summary>
		[Required(AllowEmptyStrings = false, ErrorMessage = "عنوان را وارد نمایید")]
		public string FileName { get; set; }

		/// <summary>
		/// شناسه جدول
		/// </summary>
		[Required(ErrorMessage = "شناسه جدول را وارد نمایید")]
		[Range(int.MinValue, int.MaxValue, ErrorMessage = "محدوده مقدار شناسه جدول صحیح نمی باشد")]
		public int? TableId { get; set; }

		/// <summary>
		/// شناسه سانا
		/// </summary>
		[Required(AllowEmptyStrings = false, ErrorMessage = "شناسه سانا را وارد نمایید")]
		[StringLength(36, ErrorMessage = "تعداد حروف شناسه سانا نهایتا 36 حرف می باشد")]
		public string SanaId { get; set; }

		/// <summary>
		/// شناسه رکورد
		/// </summary>
		[Required(ErrorMessage = "شناسه رکورد را وارد نمایید")]
		[Range(long.MinValue, long.MaxValue, ErrorMessage = "محدوده مقدار شناسه رکورد صحیح نمی باشد")]
		public long? RecordId { get; set; }

	}
}