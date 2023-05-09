# WebFinal


in Web.config file change connect string by your connect string:
Example:
  in tag  <connection>
       <connectionStrings>
	          <add name="ShopConnection" connectionString="Data Source=(local)\SQLEXPRESS;Initial Catalog=FINALPROJECTSE;User ID=sa;Password=sql2017" providerName="System.Data.SqlClient" />
       </connectionStrings>
  change to:
    <connectionStrings>
	          <add name="ShopConnection" connectionString="(Your connection string)" providerName="System.Data.SqlClient" />
       </connectionStrings>


