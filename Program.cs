using System.Security;
using System.Security.Cryptography.X509Certificates;

namespace Graditelj
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Client client=new Client();
            client.Make();
        }
    }
   public interface IPermission
    {
        public void Allow();
    }
    public class EditPermission : IPermission
    {
        public void Allow()
        { Console.WriteLine("User Has Edit Permission"); }
    }
    public class DeletePermission : IPermission
    {
        public void Allow()
        { Console.WriteLine("User Has Delete Permission"); }
    }
    public class CreatePermission : IPermission
    {
        public void Allow()
        { Console.WriteLine("User Has Create Permission"); }
    }
    public class ViewPermission : IPermission
    {
        public void Allow()
        { Console.WriteLine("User Has View Permission"); }
    }

    public class Account
    {
        public List<IPermission> permissions;
        public Account() { permissions = new List<IPermission>(); }
    }
    public interface AccountConfigurator
    {
        public AccountConfigurator AddEditPermission(EditPermission permission);
        public AccountConfigurator AddDeletePermission(DeletePermission permission);
        public AccountConfigurator AddCreatePermission(CreatePermission permission);
        public AccountConfigurator AddViewPermission(ViewPermission permission);
        public void Reset();
        public Account Build();
        
    }

    public class Configurator : AccountConfigurator
    {
        Account account;
        public Configurator()
        {
            this.account = new Account();
        }

        public void Reset()
        {
            account=new Account();
        }
        public AccountConfigurator AddEditPermission(EditPermission permission)
        {
            account.permissions.Add(permission);
            return this;
            
        }
        public AccountConfigurator AddDeletePermission(DeletePermission permission)
        {
            account.permissions.Add(permission);
            return this;
        }
        public AccountConfigurator AddCreatePermission(CreatePermission permission)
        {
            account.permissions.Add(permission);
            return this;
        }

        public AccountConfigurator AddViewPermission(ViewPermission permission)
        {
            account.permissions.Add(permission);
            return this;
        }

        public Account Build()
        {
            Account account = this.account;
            Reset();
            return account;
        }
    }

    public class PresetPermissions
    {
        AccountConfigurator configurator;
        public PresetPermissions(AccountConfigurator configurator)
        {
            this.configurator = configurator;
        }
        public Account Admin()
        {
            return configurator.AddEditPermission(new EditPermission()).AddDeletePermission(new DeletePermission()).AddCreatePermission(new CreatePermission()).AddViewPermission(new ViewPermission()).Build();
            //give all permission
        }
        public Account User()
        {
            return configurator.AddViewPermission(new ViewPermission()).Build();    
            //give view permission
        }
        public Account manager()
        {
            return configurator.AddEditPermission(new EditPermission()).Build();
            //give create edit view
        }
    }

    public class Client
    {
        PresetPermissions preset;
        AccountConfigurator cof;

        public void Make()
        {
            cof=new Configurator();
            preset=new PresetPermissions(cof);
            
            Account manager=preset.manager();

            foreach(IPermission per in manager.permissions)
            {
                per.Allow();
            }
           
        }
    }
}