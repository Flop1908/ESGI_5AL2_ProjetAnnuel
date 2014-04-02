package annedoctique.SAOP;

import java.io.IOException;
import java.io.InputStream;
import java.io.UnsupportedEncodingException;

import org.apache.http.HttpEntity;
import org.apache.http.HttpResponse;
import org.apache.http.ParseException;
import org.apache.http.util.EntityUtils;

import android.util.Log;
import annedoctique.managers.HttpConnexion;
import annedoctique.managers.HttpManager;
import annedoctique.model.WeatherDescription;

public class ServiceRequest {
	
	private static final String	serviceURI = "http://10.0.2.2:13839/ServiceHello.svc?singleWsdl";
	
	public static WeatherDescription getServiceRequest() throws ParseException, IOException
	{
		Log.d("ServiceRequest", "Envoi requete");
		InputStream pp;
		WeatherDescription forecast = null;
		HttpConnexion request = HttpManager.getConnectionForSoapRequest(serviceURI,
						"<s:Envelope xmlns:s=\"http://schemas.xmlsoap.org/soap/envelope/\">"
						+  "<s:Header>"
						+    "<Action s:mustUnderstand=\"1\" xmlns=\"http://schemas.microsoft.com/ws/2005/05/addressing/none\">http://tempuri.org/IServiceHello/SayHello</Action>"
						+  "</s:Header>"
						+  "<s:Body>"
						+    "<SayHello xmlns=\"http://tempuri.org/\">"
						+      "<who>Audry</who>"
						+    "</SayHello>"
						+  "</s:Body>"
						+"</s:Envelope>");
		
		
		
		pp = request.execute();
		while( pp.read() != -1)
			System.out.println(pp.read());
		
		Log.d("ServiceRequest", "Fin requete");
		/*HttpResponse response;
		response = (HttpResponse) request.execute();
		HttpEntity entity = response.getEntity();
        if (entity != null) {
             Log.d("WeatherDescription", EntityUtils.toString(entity));
        }*/
		/*
		try{
			Log.d("ServiceRequest", "début reponse");
			Log.d("ServiceRequest", request.parseHttpRequestResponse(WeatherDescription.class.getCanonicalName(), "SayHelloResponse").toString());
			Log.d("ServiceRequest", "Fin reponse");
		}catch(IndexOutOfBoundsException e){}
	*/
		return forecast;
	}

}
