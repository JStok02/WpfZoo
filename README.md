# WpfZoo

# Перед открытием приложения выполнить скрипт создания базы данных, который находится в папке ScriptDB
# Затем в файле App.config изменить строку подключения connectionStrings в data source = |ваш адрес сервера|
<connectionStrings>
    <add name="ZooDBEntities" connectionString="metadata=res://*/ZooDB.csdl|res://*/ZooDB.ssdl|res://*/ZooDB.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=|ЗДЕСЬ|;initial catalog=ZooDB;integrated security=True;encrypt=True;trustservercertificate=True;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />
</connectionStrings>
