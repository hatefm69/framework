using System;
using System.Collections.Generic;
using System;

namespace CMI.WebApi.Dto.Response
{
	/// <summary>
	/// Attahcment
	/// </summary>
	public class OutAttachment
	{
		// Properties.
		/// <summary>
		/// شناسه
		/// </summary>
		public long Id { get; set; }

		/// <summary>
		/// عنوان
		/// </summary>
		public string FileName { get; set; }

		/// <summary>
		/// شناسه جدول
		/// </summary>
		public int TableId { get; set; }

		/// <summary>
		/// شناسه سانا
		/// </summary>
		public string SanaId { get; set; }

		/// <summary>
		/// شناسه رکورد
		/// </summary>
		public long RecordId { get; set; }

	}
}