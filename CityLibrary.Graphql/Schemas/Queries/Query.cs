using System;
using CityLibraryInfrastructure.ExceptionHandling;

namespace CityLibrary.Graphql.Schemas.Queries
{
	public class Query
	{
		public TestType BasicQuery()
		{
			return new TestType("test", 123);
		}
		
		public TestType ThrowCustomException()
		{
			throw new CustomException("Not found");
			return new TestType("test", 123);
		}
		
		public TestType ThrowInternalException()
		{
			var a = 1;
			var b = 0;
			var c = a / b;
			return new TestType("test", 123);
		}
	}
}

