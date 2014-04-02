package annedoctique.page;

import java.io.IOException;
import java.io.InputStream;
import java.io.UnsupportedEncodingException;

import org.apache.http.HttpEntity;
import org.apache.http.HttpResponse;
import org.apache.http.ParseException;
import org.apache.http.client.HttpClient;
import org.apache.http.client.methods.HttpGet;
import org.apache.http.impl.client.DefaultHttpClient;
import org.apache.http.protocol.BasicHttpContext;
import org.apache.http.protocol.HttpContext;

import android.app.Activity;
import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.os.Handler;
import android.util.Log;
import annedoctique.SAOP.ServiceRequest;

public class SplashScreen extends Activity{

	 private static int SPLASH_TIME_OUT = 3000;
	 private static boolean bConnexionInternet = false;
	 
	    @Override
	    protected void onCreate(Bundle savedInstanceState) {
	        super.onCreate(savedInstanceState);
	        setContentView(R.layout.activity_splash_screen);
	        
	        new synchroniseAllData().execute();
	    }
	    
	    private class synchroniseAllData extends AsyncTask<Void, Void, String>{


	    	
	    	/**
	    	 * Recupere les dernieres anecdocte de chaque application
	    	 * Si l'utilisateur a une connexion internet, remplace les anciennes par les nouvelles
	    	 * sinon on attends 3s et l'utilisateur reli les anciennes nouvelles. 
	    	 */
			
			/*protected Void doInBackground(Void... arg0) {
				/*try {
					ServiceRequest.getServiceRequest();
				} catch (UnsupportedEncodingException e) {e.printStackTrace();} catch (ParseException e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				} catch (IOException e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				}*/
				

						
	
	            //return null;
			//}
			
			protected String getASCIIContentFromEntity(HttpEntity entity) throws IllegalStateException, IOException {
				InputStream in = entity.getContent();
				StringBuffer out = new StringBuffer();
				int n = 1;
				while (n>0) {
					byte[] b = new byte[4096];
					n =  in.read(b);
					if (n>0) out.append(new String(b, 0, n));
				}
				return out.toString();
			}
			
			
			protected String doInBackground(Void... params) {
				HttpClient httpClient = new DefaultHttpClient();
				HttpContext localContext = new BasicHttpContext();
				String text = null;
				try {
					HttpResponse response = httpClient.execute(new  HttpGet("http://10.0.2.2:13839/ServiceHello.svc/CNF_RetreiveAnecdote/last/10/1"), localContext);
					HttpEntity entity = response.getEntity();
					text = getASCIIContentFromEntity(entity);
				} catch (Exception e) {
					
				}

				Log.v("JSON",text);
				return text;
			}	
			
			protected void onPostExecute(String results) {
				//super.onPostExecute();
				/*Intent i = new Intent(SplashScreen.this, GeneralActivity.class);
	            i.putExtra("now_playing", "toto");
	            i.putExtra("earned", "titi");
	            startActivity(i);*/
	            Log.v("JSON", results);
	            // close this activity
	           
	            
	            new Handler().postDelayed(new Runnable() {
	           	 
		            /*
		             * Showing splash screen with a timer. This will be useful when you
		             * want to show case your app logo / company
		             */
		 
		            @Override
		            public void run() {
		                // This method will be executed once the timer is over
		                // Start your app main activity
		                Intent i = new Intent(SplashScreen.this, GeneralActivity.class);
		                startActivity(i);
		 
		                // close this activity
		                finish();
		            }
		        }, SPLASH_TIME_OUT);
			}

	    	
	    }
}
