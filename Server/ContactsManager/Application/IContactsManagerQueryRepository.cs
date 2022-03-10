namespace Application
{
	using Domain.Models;
	using System.Threading;
	using System.Threading.Tasks;

	public interface IContactsManagerQueryRepository : IQueryRepository<Contact>
	{
		//Task<EmployeeSurveyOutputModel> GetEmployeeSurveyDetails(int employeeSurveyId, CancellationToken cancellationToken = default);
	}
}
