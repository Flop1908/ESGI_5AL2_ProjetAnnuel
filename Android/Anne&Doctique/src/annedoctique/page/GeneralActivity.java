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
		static String[] ListeExemple = {"Aujourd'hui, depuis que les médias ont raconté comment je m'étais fait agresser alors que je traînais fortuitement dans un des repères à toxicomanes de Los Angeles, je suis victime d'un véritable…","Aujourd'hui, cela fait quelques mois que je fais des crises de spasmophilie. Avant d'entrer en cours, ma classe tout entière s'est rassemblée autour de moi et m'a ordonné d'en faire une \"pour annuler le contrôle et glander !\" VDM"
			,"Aujourd'hui, mon père, 60 ans, me demande de lui expliquer la différence entre Google, YouTube et Facebook. Je passe plusieurs minutes à bien lui expliquer en illustrant. A la fin, il acquiesce puis me dit : \"OK, mais l'internet, c'est quoi alors ?\" VDM"
			,"Aujourd'hui, je rencontre pour la première fois une fille avec qui je discute depuis plusieurs semaines sur un site de rencontres. La première phrase qu'elle me sort après m'avoir dit bonjour est : \"Ah... Je n'avais pas remarqué sur les photos que tu étais roux. On peut quand même être amis ?\" VDM"
			,"Aujourd'hui, cela fait une semaine que mon labrador est au régime. Il a eu tellement faim cette nuit qu'il a mangé l'éponge de la cuisine, laissant juste la partie grattante verte. VDM"
			,"Aujourd'hui, au supermarché, un homme a fait un malaise et une foule s'est formée autour de lui. Ma mère s'est écriée : \"Écartez-vous ! Je suis médecin.\" Elle ne l'est pas. VDM"
			,"Aujourd'hui, j'ai accompagné ma mère chez ses amis. Pendant le repas, elle a décidé de leur montrer son nouveau tatouage. Il se situe sur ses fesses. Je crois que les enfants de ses amis sont traumatisés. VDM"
			,"Aujourd'hui, mon copain m'a lancé un regard coquin. Je lui ai fait comprendre que ça ne serait pas possible, car j'étais dans la mauvaise période du mois. Il a alors pris la voix de Gollum et m'a chuchoté à l'oreille : \"Gollum connait un autre chemin... Le tunnel !\" VDM"
			,"Aujourd'hui, j'ai montré mes albums photo à ma fille. Intéressée, elle s'est arrêtée sur une photo et a demandé : \"C'était Halloween ?\" Non, c'étaient mes fiançailles. VDM"
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
