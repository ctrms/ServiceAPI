namespace Boyner.API.Exceptions
{
	public class Argument
	{
		public static void CheckIfNull(object checkObject, string paramName)
		{
			if (checkObject == null)
			{
				throw new WorkflowException($"Parametre boş bırakılamaz. Parametre Adı: {paramName}");
			}
		}

		public static void CheckIfNull(object checkObject, string paramName, string message)
		{
			if (checkObject == null)
			{
				throw new WorkflowException(message);
			}
		}

		public static void ThrowWorkflowException(string message)
		{
			throw new WorkflowException(message);
		}

		public static void CheckIfNullOrEmpty(string checkObject, string paramName)
		{
			if (string.IsNullOrEmpty(checkObject))
			{
				throw new WorkflowException($"Parametre boş bırakılamaz. Parametre Adı: {paramName}");
			}
		}
	}
}
