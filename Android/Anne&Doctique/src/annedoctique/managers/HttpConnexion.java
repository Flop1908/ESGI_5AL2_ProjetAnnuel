package annedoctique.managers;

import java.io.IOException;
import java.io.InputStream;
import java.net.SocketException;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Iterator;
import java.util.Map.Entry;

import javax.xml.parsers.ParserConfigurationException;
import javax.xml.parsers.SAXParser;
import javax.xml.parsers.SAXParserFactory;

import org.apache.http.HttpResponse;
import org.apache.http.client.ClientProtocolException;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.entity.AbstractHttpEntity;
import org.xml.sax.SAXException;

import android.util.Log;
import annedoctique.SAOP.GenericComplexType;
import annedoctique.SAOP.SoapResponseParserHandler;

public class HttpConnexion {
	private 	String						mURI;
	protected 	AbstractHttpEntity			mEntity;
	private 	HashMap<String, String>		mHttpHeaders;
	private	 	HttpPost 					mPostRequest;

	HttpConnexion(){
		mHttpHeaders = new HashMap<String, String>();
	}

	public void setHeader(String key, String value){
		mHttpHeaders.remove(key);
		mHttpHeaders.put(key, value);
	}

	public InputStream execute() throws NullPointerException{
		//Initialisation de la requête
		Log.d("HttpConnexion", "1");
		mPostRequest = new HttpPost(mURI);

		//Ajout des headers personnalisés
		Iterator<Entry<String, String>> iterator = mHttpHeaders.entrySet().iterator();
		Log.d("HttpConnexion", "2");
		while(iterator.hasNext()){
			Entry<String, String> entry = iterator.next();
			mPostRequest.setHeader(entry.getKey(), entry.getValue());
		}
		Log.d("HttpConnexion", "3");
		HttpResponse httpResponse;
		//Envoi de la requête
		boolean retry = false;
		try {		
			Log.d("HttpConnexion", "4");
			mPostRequest.setEntity(mEntity);
			httpResponse = HttpManager.getClient().execute(mPostRequest);
			return httpResponse.getEntity().getContent();
		} 
		catch (SocketException e) {retry = true;} 
		catch (IOException e) {retry = true;}
		
		Log.d("HttpConnexion", "5");
		if(retry){
			try {
				Log.d("HttpConnexion", "6");
				httpResponse = HttpManager.getClient().execute(mPostRequest);
				return httpResponse.getEntity().getContent();
			} 
			catch (ClientProtocolException e1) {e1.printStackTrace();} 
			catch (IOException e1) {e1.printStackTrace();}	
		}

		throw new NullPointerException("Le flux de données renvoyé est nul");
	}

	public ArrayList<GenericComplexType> parseHttpRequestResponse(String returnClassName, String newObjectTag) throws NullPointerException{
		try {
			Log.d("parseHttpRequestResponse", "début reponse");
			SAXParserFactory factory = SAXParserFactory.newInstance();
			SAXParser parser = factory.newSAXParser();
			Log.d("parseHttpRequestResponse", "2");
			SoapResponseParserHandler handler = new SoapResponseParserHandler(returnClassName, newObjectTag);
			parser.parse(execute(), handler);
			Log.d("parseHttpRequestResponse", "3");
			Log.d("parseHttpRequestResponse", "4 : handle = " + handler.getResults().toString());
			mPostRequest.abort();
			return handler.getResults();
		} 
		catch (ParserConfigurationException e) {e.printStackTrace();} 
		catch (SAXException e) {e.printStackTrace();} 
		catch (IOException e) {e.printStackTrace();}

		return null;
	}

	public String getmURI() {
		return mURI;
	}

	public void setmURI(String mURI) {
		this.mURI = mURI;
	}

	public AbstractHttpEntity getmEntity() {
		return mEntity;
	}

	public void setmEntity(AbstractHttpEntity mEntity) {
		this.mEntity = mEntity;
	}

	public HashMap<String, String> getmHttpHeaders() {
		return mHttpHeaders;
	}

	public void setmHttpHeaders(HashMap<String, String> mHttpHeaders) {
		this.mHttpHeaders = mHttpHeaders;
	}

	public HttpPost getmPostRequest() {
		return mPostRequest;
	}

	public void setmPostRequest(HttpPost mPostRequest) {
		this.mPostRequest = mPostRequest;
	}
}
