namespace Domain.Exceptions
{
	using Domain.Validation;

	public class InvalidContactException : BaseDomainException
	{
		public InvalidContactException()
		{
		}

		public InvalidContactException(string error) => this.Error = error;
	}
}
