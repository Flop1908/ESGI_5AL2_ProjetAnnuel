package annedoctique.SAOP;

import java.util.ArrayList;

import org.xml.sax.Attributes;
import org.xml.sax.SAXException;
import org.xml.sax.helpers.DefaultHandler;

import android.util.Log;

public class SoapResponseParserHandler extends DefaultHandler{
	private ArrayList<GenericComplexType> 		mRecoveredObjects;
	private GenericComplexType					mCurrentObject;
	
	private StringBuffer						mCapturedString;

	private String								mNewObjectTag;
	private String								mReturnClassName;
	
	private boolean								mSessionExists;

	public SoapResponseParserHandler(String returnClassName, String newObjectTag){
		mRecoveredObjects = new ArrayList<GenericComplexType>();
		mReturnClassName = returnClassName;
		mNewObjectTag = newObjectTag;
		mSessionExists = false;
		
		Object o = getInstanceOf(returnClassName);
		if(o == null)
			throw new IllegalArgumentException();
		if(!(o instanceof GenericComplexType))
			throw new IllegalArgumentException();
	}

	//détection d'ouverture de balise
	public void startElement(String uri, String localName,
			String qName, Attributes attributes) throws SAXException{
		mCapturedString = new StringBuffer();
		
		if(localName.equals(mNewObjectTag)){
			mCurrentObject = (GenericComplexType)getInstanceOf(mReturnClassName);
		}
		if(mCurrentObject != null){
			mCurrentObject.startElement(localName);
		}
	}

	//détection fin de balise
	public void endElement(String uri, String localName, String qualifiedName){  
		String captured = mCapturedString.toString();
		Log.e("SOAP", captured);
		
		if(localName.equals(mNewObjectTag)){
			mRecoveredObjects.add(mCurrentObject);
			mCurrentObject = null;
		}
		if(mCurrentObject != null){
			mCurrentObject.setValue(localName, captured);
		}
		if(localName.equals("SessionExists")){
			mSessionExists = (captured.equals("true"))?true:false;
		}
	}

	//détection de caractères
	public void characters(char[] ch,int start, int length)
	throws SAXException{
		mCapturedString.append(ch, start, length);
	}

	//début du parsing
	public void startDocument() throws SAXException {
	}

	//fin du parsing
	public void endDocument() throws SAXException {
	}
	
	public ArrayList<GenericComplexType> getResults(){
		return mRecoveredObjects;
	}
	
	public boolean sessionExists(){
		return mSessionExists;
	}

	public Object getInstanceOf(String className){
		Class [] classParm = null;
		Object [] objectParm = null;

		try {
			Class cl = Class.forName(className);
			java.lang.reflect.Constructor co = cl.getConstructor(classParm);
			return co.newInstance(objectParm);
		}
		catch (Exception e) {
			e.printStackTrace();
			return null;
		}
	}
}
