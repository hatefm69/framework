namespace CMI.WebApi.Dto.Request;

public class InDelete : InputsValidator<InDelete>
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "شناسه یکتا را وارد نمایید")]
    public long? Id { get; set; }
}