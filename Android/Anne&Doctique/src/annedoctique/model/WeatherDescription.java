/*
 * Author : Alexandre OBELLIANNE
 * Contact : morphet (little internet a) laposte.net
 * 
 * 06/11/2011
 * 
 * (c)Copyright - 2011 Alexandre OBELLIANNE
 *
 * Published under GPL : http://www.gnu.org/licenses/gpl.txt
 * 
 * 
 * This file is part of TutoSOAP.
 * 
 * TutoSOAP is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * TutoSOAP is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with TutoSOAP.  If not, see <http://www.gnu.org/licenses/>.
 * 
 * 
 * This project utilizes the CDYNE Corporation Weather Webservice (please refer to http://wiki.cdyne.com/index.php/CDYNE_Weather).
 * This is a free web service offered by CDYNE as an advertisment for its commercial web services.
 * 
 */
package annedoctique.model;

import java.io.ByteArrayOutputStream;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.InputStream;

import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.util.Log;
import annedoctique.SAOP.GenericComplexType;
import annedoctique.managers.HttpManager;

public class WeatherDescription implements GenericComplexType {
	
	public int 		weatherID;
	public String	description;
	public String 	pictureURL;
	public Bitmap	picture;

	@Override
	public void setValue(String tagName, String value) {
		Log.d("WeatherDescription", tagName + " = " + value);
	}

	@Override
	public void startElement(String tagName) {
		// TODO Auto-generated method stub
		
	}
	
	private void retrievePicture(){
		new Thread(){
			public void run(){
				try {
					Log.d("WeatherDescription", "1");
					ByteArrayOutputStream baos = new ByteArrayOutputStream();
					InputStream is = HttpManager.getConnectionForEmptyRequest(pictureURL).execute();
					byte[] bytes = new byte[2048];
					int read = 0;
					Log.d("WeatherDescription", "2");
					while((read = is.read(bytes)) != -1){
						baos.write(bytes, 0, read);
						Log.d("Reponse : ", ""+read);
					}
					Log.d("WeatherDescription", "3");
					baos.flush();
					baos.close();
					picture = BitmapFactory.decodeByteArray(baos.toByteArray(), 0, baos.size());
				} catch (FileNotFoundException e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				} catch (IOException e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				}
			}
		}.start();
	}

}
