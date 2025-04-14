using SmartTransit.Domain.Domains.DTO;
 using SmartTransit.Domain.Gateway.User;
 using SmartTransit.Domain.Security.Criptography;
 using SmartTransit.Domain.UseCases;
 using SmartTransit.Domain.UseCases.Login;

 namespace SmartTransit.Domain.Services;
 
 public class LoginCrudUseService : ILoginCrudUseCase
 {
     private readonly IUserRepositoryGateway _repositoryGateway;
     private readonly IJwtCrudUseCase _jwtCrudUseCase;
     private readonly IPasswordEncripter _passwordEncripter;
 
     public LoginCrudUseService(IUserRepositoryGateway repositoryGateway, IJwtCrudUseCase jwtCrudUseCase,
         IPasswordEncripter passwordEncripter)
     {
         _repositoryGateway = repositoryGateway;
         _jwtCrudUseCase = jwtCrudUseCase;
         _passwordEncripter = passwordEncripter;
     }
 
     public async Task<LoginResponseDTO> LoginUser(LoginDTO loginDto)
     {
         var user = await _repositoryGateway.GetByEmail(loginDto.Email);
 
         if (user == null)
         {
             throw new UnauthorizedAccessException("Invalid credentials: User not found.");
         }
       
         if (!_passwordEncripter.IsValid(loginDto.Password, user.PasswordHash))
         {
             throw new UnauthorizedAccessException("Invalid credentials: Incorrect password.");
         }
         
         return _jwtCrudUseCase.GenerateTokens(user);
     }
 }