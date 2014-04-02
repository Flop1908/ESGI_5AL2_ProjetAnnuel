package annedoctique.managers;

import java.io.IOException;
import java.io.UnsupportedEncodingException;

import org.apache.http.HttpEntityEnclosingRequest;
import org.apache.http.HttpRequest;
import org.apache.http.HttpVersion;
import org.apache.http.NoHttpResponseException;
import org.apache.http.client.HttpRequestRetryHandler;
import org.apache.http.conn.params.ConnManagerPNames;
import org.apache.http.conn.params.ConnPerRouteBean;
import org.apache.http.conn.scheme.PlainSocketFactory;
import org.apache.http.conn.scheme.Scheme;
import org.apache.http.conn.scheme.SchemeRegistry;
import org.apache.http.entity.StringEntity;
import org.apache.http.impl.client.DefaultHttpClient;
import org.apache.http.impl.conn.tsccm.ThreadSafeClientConnManager;
import org.apache.http.params.BasicHttpParams;
import org.apache.http.params.HttpProtocolParams;
import org.apache.http.protocol.ExecutionContext;
import org.apache.http.protocol.HttpContext;

import android.util.Log;

public class HttpManager {
	
	private static DefaultHttpClient client;
	
	public static DefaultHttpClient getClient() {
		return client;
	}

	//Spécifique a SAOP
	public static HttpConnexion getConnectionForSoapRequest(String uri, String request) throws UnsupportedEncodingException{
		
		if(client == null){
			initClient();
		}
		HttpConnexion connection = new HttpConnexion();
		connection.setmURI(uri);
		connection.setmEntity(new StringEntity(request)) ;
		connection.getmEntity().setContentEncoding("UTF-8");
		connection.setHeader("Content-Type", "text/xml; charset=utf-8");
		return connection;
	}
	
	public static HttpConnexion getConnectionForEmptyRequest(String uri){
		if(client == null){
			initClient();
		}
		HttpConnexion connection = new HttpConnexion();
		connection.setmURI(uri);
		return connection;
	}
	
	private static void initClient(){
		SchemeRegistry schemeRegistry = new SchemeRegistry();
		schemeRegistry.register(new Scheme("http", PlainSocketFactory.getSocketFactory(), 80));

		BasicHttpParams params = new BasicHttpParams();
		params.setParameter(ConnManagerPNames.MAX_TOTAL_CONNECTIONS,1);
		params.setParameter(ConnManagerPNames.MAX_CONNECTIONS_PER_ROUTE, new ConnPerRouteBean(1));
		params.setParameter(HttpProtocolParams.USE_EXPECT_CONTINUE, false);

		HttpProtocolParams.setVersion(params, HttpVersion.HTTP_1_1);

		ThreadSafeClientConnManager clientConnectionManager = new ThreadSafeClientConnManager(params, schemeRegistry);
		client = new DefaultHttpClient(clientConnectionManager, params);
		setDefaultRetryHandler();
	}
	
	private static void setDefaultRetryHandler(){
		HttpRequestRetryHandler retryHandler = 
			new HttpRequestRetryHandler(){
			
			public boolean retryRequest(IOException exception, int executionCount,HttpContext context) 
			{
				if (executionCount >= 5)
					return false;
				
				//Si pas de réponse, on retente
				if (exception instanceof NoHttpResponseException)
					return true;
				
				//On retente si la poignée de main SSL a echoué
				if (exception instanceof IOException)
					return true;
				
				HttpRequest request = (HttpRequest)context.getAttribute(ExecutionContext.HTTP_REQUEST);
				boolean incomplet = !(request instanceof HttpEntityEnclosingRequest); 
				
				//On ré-essaye si la requête est considérée incomplete
				if (incomplet)
					return true;
				return false;
			}

		};

		client.setHttpRequestRetryHandler(retryHandler);
	}

	public static void setRetryHandler(HttpRequestRetryHandler handler){
		client.setHttpRequestRetryHandler(handler);
	}

}
