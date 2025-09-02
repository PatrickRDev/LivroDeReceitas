using RecipeBook.Communication.Requests;
using RecipeBook.Communication.Responses;
using RecipeBook.Exceptions.ExceptionsBase;

namespace RecipeBook.Application.UseCases.User.Register
{
    public class RegisterUseCase
    {

        public ResponseRegisteredUserJson Execute(RequestRegisterUserJson request)
        {

            Validate(request);
            return new ResponseRegisteredUserJson
            {
                Name = request.Name
            };
        }


        private void Validate(RequestRegisterUserJson request)
        {
            var validator = new RegisterUserValidator();
            var result = validator.Validate(request);

            if(result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }


      
}
