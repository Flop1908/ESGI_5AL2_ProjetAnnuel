//
//  ViewController.h
//  MaskedExample
//
//  Created by Kevin Donnelly on 4/1/14.
//
//

#import <UIKit/UIKit.h>
#import "AnnePageControl.h"


@interface ViewController : UIViewController <UIScrollViewDelegate, AnnePageControlDataSource>
@property (weak, nonatomic) IBOutlet UIScrollView *scrollView;
@property (weak, nonatomic) AnnePageControl *pageControl;
@property (weak, nonatomic) IBOutlet AnnePageControl *nibPageControl;

@end
