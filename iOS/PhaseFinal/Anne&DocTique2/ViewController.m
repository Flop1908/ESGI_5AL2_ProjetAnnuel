//
//  ViewController.m
//  MaskedExample
//
//  Created by Kevin Donnelly on 4/1/14.
//
//

#import "ViewController.h"

@implementation ViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    
    //number of pages in this application
    NSInteger pages = 5;
    
    //reservation and definition of this pageControl
    AnnePageControl *pageControl = [[AnnePageControl alloc] init];
    [pageControl setNumberOfPages:pages];
    [pageControl setCenter:CGPointMake(CGRectGetMidX(self.view.bounds), CGRectGetHeight(self.view.bounds) - CGRectGetMidY(pageControl.bounds) - 10)];
    [pageControl setDataSource:self];
    [pageControl setHidesForSinglePage:YES];
    
    [self.nibPageControl setNumberOfPages:pages];

    [self.view addSubview:pageControl];
    self.pageControl = pageControl;
    
    [self createPages:pages];
    
    [self.pageControl addTarget:self action:@selector(changePage:) forControlEvents:UIControlEventValueChanged];
    [self.nibPageControl addTarget:self action:@selector(changePage:) forControlEvents:UIControlEventValueChanged];
}
//Creation of X pages
- (void)createPages:(NSInteger)pages {
    for (int i = 0; i < pages; i++) {
        //allocation on user view
        UIView *view = [[UIView alloc] initWithFrame:CGRectMake(CGRectGetWidth(self.scrollView.bounds) * i, 0, CGRectGetWidth(self.scrollView.bounds), CGRectGetHeight(self.scrollView.bounds))];
        UILabel *label = [[UILabel alloc] init];
        [label setText:[NSString stringWithFormat:@"%i", i+1]];
        [label setFont:[UIFont boldSystemFontOfSize:90]];
        
        [label sizeToFit];
        [label setCenter:CGPointMake(CGRectGetMidX(view.bounds), CGRectGetMidY(view.bounds))];

        if (i % 5 == 1)//screen of chrono
        {
            [view setBackgroundColor:[UIColor blueColor]];
            [label setTextColor:[UIColor whiteColor]];
        }
        else if (i % 5 == 2)//screen of flop
        {
            [view setBackgroundColor:[UIColor brownColor]];
            [label setTextColor:[UIColor whiteColor]];
        }
        else if (i % 5 == 3)//screen of random
        {
            [view setBackgroundColor:[UIColor magentaColor]];
            [label setTextColor:[UIColor whiteColor]];
        }
        else if (i % 5 == 4)//screen of flux
        {
            [view setBackgroundColor:[UIColor purpleColor]];
            [label setTextColor:[UIColor whiteColor]];
        }
        else if(i % 5 ==0)//screen of top
        {
            [view setBackgroundColor:[UIColor whiteColor]];
            [label setTextColor:[UIColor darkGrayColor]];
        }
        
        [view addSubview:label];
        [self.scrollView addSubview:view];
    }
    
    [self.scrollView setContentSize:CGSizeMake(CGRectGetWidth(self.scrollView.bounds) * pages, CGRectGetHeight(self.scrollView.bounds))];
}

#pragma mark - UIScrollViewDelegate
- (void)scrollViewDidScroll:(UIScrollView *)scrollView {
    [self.pageControl maskEventWithOffset:scrollView.contentOffset.x frame:scrollView.frame];
    [self.nibPageControl maskEventWithOffset:scrollView.contentOffset.x frame:scrollView.frame];
}

- (void)scrollViewDidEndDecelerating:(UIScrollView *)scrollView {
    CGFloat pageWidth = self.scrollView.frame.size.width;
	NSInteger page =  floor((self.scrollView.contentOffset.x - pageWidth / 2) / pageWidth) + 1;
    
    [self.pageControl setCurrentPage:page];
    [self.nibPageControl setCurrentPage:page];
}

- (void)scrollViewDidEndScrollingAnimation:(UIScrollView *)scrollView {
    CGFloat pageWidth = self.scrollView.frame.size.width;
	NSInteger page =  floor((self.scrollView.contentOffset.x - pageWidth / 2) / pageWidth) + 1;
    
    [self.pageControl setCurrentPage:page];
    [self.nibPageControl setCurrentPage:page];
}

#pragma mark - IBActions
- (void)changePage:(AnnePageControl *)sender {
	self.pageControl.currentPage = sender.currentPage;
	self.nibPageControl.currentPage = sender.currentPage;
	
    CGRect frame = self.scrollView.frame;
    frame.origin.x = frame.size.width * self.pageControl.currentPage;
    frame.origin.y = 0;
    [self.scrollView scrollRectToVisible:frame animated:YES];
}

#pragma mark - KVNMaskedPageControlDataSource
- (UIColor *)pageControl:(AnnePageControl *)control pageIndicatorTintColorForIndex:(NSInteger)index {
    if (index % 2 == 0) {
        return [UIColor colorWithWhite:1.0 alpha:.6];
    } else {
        return [UIColor colorWithWhite:0 alpha:.5];
    }
}

- (UIColor *)pageControl:(AnnePageControl *)control currentPageIndicatorTintColorForIndex:(NSInteger)index {
    if (index % 2 == 0) {
        return nil; // nil just sets the default UIPageControl color or respects UIAppearance setting.
    } else {
        return [UIColor colorWithWhite:0 alpha:.8];

    }
}

@end
