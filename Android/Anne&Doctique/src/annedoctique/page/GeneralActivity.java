package annedoctique.page;

import java.util.Locale;

import android.content.Context;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentActivity;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentPagerAdapter;
import android.support.v4.view.ViewPager;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ListView;

public class GeneralActivity extends FragmentActivity {

	/**
	 * The {@link android.support.v4.view.PagerAdapter} that will provide
	 * fragments for each of the sections. We use a
	 * {@link android.support.v4.app.FragmentPagerAdapter} derivative, which
	 * will keep every loaded fragment in memory. If this becomes too memory
	 * intensive, it may be best to switch to a
	 * {@link android.support.v4.app.FragmentStatePagerAdapter}.
	 */
	SectionsPagerAdapter mSectionsPagerAdapter;

	/**
	 * The {@link ViewPager} that will host the section contents.
	 */
	ViewPager mViewPager;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_general);

		// Create the adapter that will return a fragment for each of the three
		// primary sections of the app.
		mSectionsPagerAdapter = new SectionsPagerAdapter(
				getSupportFragmentManager());

		// Set up the ViewPager with the sections adapter.
		mViewPager = (ViewPager) findViewById(R.id.pager);
		mViewPager.setAdapter(mSectionsPagerAdapter);

	}
	
	public void onWindowFocusChanged(boolean hasFocus) {
        super.onWindowFocusChanged(hasFocus);
	   /* if (hasFocus) 
	    {
	    	mViewPager.setSystemUiVisibility(
	                View.SYSTEM_UI_FLAG_LAYOUT_STABLE
	                | View.SYSTEM_UI_FLAG_LAYOUT_HIDE_NAVIGATION
	                | View.SYSTEM_UI_FLAG_LAYOUT_FULLSCREEN
	                | View.SYSTEM_UI_FLAG_HIDE_NAVIGATION
	                | View.SYSTEM_UI_FLAG_FULLSCREEN
	                | View.SYSTEM_UI_FLAG_IMMERSIVE_STICKY);
	    }*/
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.general, menu);
		return true;
	}

	/**
	 * A {@link FragmentPagerAdapter} that returns a fragment corresponding to
	 * one of the sections/tabs/pages.
	 */
	public class SectionsPagerAdapter extends FragmentPagerAdapter {

		public SectionsPagerAdapter(FragmentManager fm) {
			super(fm);
		}

		@Override
		public Fragment getItem(int position) {
			// getItem is called to instantiate the fragment for the given page.
			// Return a DummySectionFragment (defined as a static inner class
			// below) with the page number as its lone argument.
			Fragment fragment = new DummySectionFragment();
			Bundle args = new Bundle();
			args.putInt(DummySectionFragment.ARG_SECTION_NUMBER, position + 1);
			fragment.setArguments(args);
			return fragment;
		}

		@Override
		public int getCount() {
			// Show 3 total pages.
			return 3;
		}

		@Override
		public CharSequence getPageTitle(int position) {
			Locale l = Locale.getDefault();
			switch (position) {
			case 0:
				return getString(R.string.title_section1).toUpperCase(l);
			case 1:
				return getString(R.string.title_section2).toUpperCase(l);
			case 2:
				return getString(R.string.title_section3).toUpperCase(l);
			}
			return null;
		}
	}

	/**
	 * A dummy fragment representing a section of the app, but that simply
	 * displays dummy text.
	 */
	public static class DummySectionFragment extends Fragment {
		/**
		 * The fragment argument representing the section number for this
		 * fragment.
		 */
		public static final String ARG_SECTION_NUMBER = "section_number";
		static String[] ListeExemple = {"Aujourd'hui, depuis que les m�dias ont racont� comment je m'�tais fait agresser alors que je tra�nais fortuitement dans un des rep�res � toxicomanes de Los Angeles, je suis victime d'un v�ritable�","Aujourd'hui, cela fait quelques mois que je fais des crises de spasmophilie. Avant d'entrer en cours, ma classe tout enti�re s'est rassembl�e autour de moi et m'a ordonn� d'en faire une \"pour annuler le contr�le et glander !\" VDM"
			,"Aujourd'hui, mon p�re, 60 ans, me demande de lui expliquer la diff�rence entre Google, YouTube et Facebook. Je passe plusieurs minutes � bien lui expliquer en illustrant. A la fin, il acquiesce puis me dit : \"OK, mais l'internet, c'est quoi alors ?\" VDM"
			,"Aujourd'hui, je rencontre pour la premi�re fois une fille avec qui je discute depuis plusieurs semaines sur un site de rencontres. La premi�re phrase qu'elle me sort apr�s m'avoir dit bonjour est : \"Ah... Je n'avais pas remarqu� sur les photos que tu �tais roux. On peut quand m�me �tre amis ?\" VDM"
			,"Aujourd'hui, cela fait une semaine que mon labrador est au r�gime. Il a eu tellement faim cette nuit qu'il a mang� l'�ponge de la cuisine, laissant juste la partie grattante verte. VDM"
			,"Aujourd'hui, au supermarch�, un homme a fait un malaise et une foule s'est form�e autour de lui. Ma m�re s'est �cri�e : \"�cartez-vous ! Je suis m�decin.\" Elle ne l'est pas. VDM"
			,"Aujourd'hui, j'ai accompagn� ma m�re chez ses amis. Pendant le repas, elle a d�cid� de leur montrer son nouveau tatouage. Il se situe sur ses fesses. Je crois que les enfants de ses amis sont traumatis�s. VDM"
			,"Aujourd'hui, mon copain m'a lanc� un regard coquin. Je lui ai fait comprendre que �a ne serait pas possible, car j'�tais dans la mauvaise p�riode du mois. Il a alors pris la voix de Gollum et m'a chuchot� � l'oreille : \"Gollum connait un autre chemin... Le tunnel !\" VDM"
			,"Aujourd'hui, j'ai montr� mes albums photo � ma fille. Int�ress�e, elle s'est arr�t�e sur une photo et a demand� : \"C'�tait Halloween ?\" Non, c'�taient mes fian�ailles. VDM"
			,"tete"}; 
		ArrayAdapter<String> adapter;
		
		public DummySectionFragment() {
		}

		@Override
		public View onCreateView(LayoutInflater inflater, ViewGroup container,
				Bundle savedInstanceState) {
			View rootView = inflater.inflate(R.layout.fragment_general_dummy,
					container, false);
			/*TextView dummyTextView = (TextView) rootView
					.findViewById(R.id.section_label);*/
			ListView dymmyListView = (ListView) rootView.findViewById(R.id.list);
			
			Context c = getActivity();
			adapter = new ArrayAdapter<String>(c, android.R.layout.simple_list_item_1, ListeExemple);
			dymmyListView.setAdapter(adapter);
			
			/*dummyTextView.setText(Integer.toString(getArguments().getInt(
					ARG_SECTION_NUMBER)));*/
			return rootView;
		}
		
	}

}
